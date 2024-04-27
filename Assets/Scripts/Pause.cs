using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundImage;
    [SerializeField] private Sprite muteImage;

    void Start()
    {
        if (PlayerPrefs.GetInt("isSound") == 1)
            soundButtonImage.sprite = soundImage;
        else if (PlayerPrefs.GetInt("isSound") == 0)
            soundButtonImage.sprite = muteImage;

        PausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausePanel.activeSelf) 
            {
                OnClickResume();
            }
            else
            {
                PausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
            }
        }
    }

    public void OnClickSound()
    {
        if (PlayerPrefs.GetInt("isSound") == 1)
        {
            PlayerPrefs.SetInt("isSound", 0);
            AudioListener.volume = 0;
            soundButtonImage.sprite = muteImage;
        }
        else if (PlayerPrefs.GetInt("isSound") == 0)
        {
            PlayerPrefs.SetInt("isSound", 1);
            AudioListener.volume = 1;
            soundButtonImage.sprite = soundImage;
        }
    }

    public void OnClickResume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PausePanel.SetActive(false);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickPrevious()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnClickMenu()
    {
        Destroy(GameObject.Find("MusicManager(Clone)"));
        SceneManager.LoadScene(0);
    }

    public void OnSensitivityChanged()
    {
        cameraController.sensetivityMouse = sensitivitySlider.value;
        PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
    }
}
