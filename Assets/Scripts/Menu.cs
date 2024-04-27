using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundImage;
    [SerializeField] private Sprite muteImage;
    [SerializeField] private GameObject musicManagerPref;

    void Start()
    {
        if (PlayerPrefs.HasKey("isSound"))
        {
            if (PlayerPrefs.GetInt("isSound") == 1)
                soundButtonImage.sprite = soundImage;
            else if (PlayerPrefs.GetInt("isSound") == 0)
                soundButtonImage.sprite = muteImage;
        }
        else
        {
            PlayerPrefs.SetInt("isSound", 1);
            soundButtonImage.sprite = soundImage;
        }

        if (!PlayerPrefs.HasKey("levelsCompleted"))
            PlayerPrefs.SetInt("levelsCompleted", 0);
    }

    public void OnClickPlay()
    {
        GameObject musicManager = Instantiate(musicManagerPref);
        DontDestroyOnLoad(musicManager);
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelsCompleted") + 1);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickSound()
    {
        if (PlayerPrefs.GetInt("isSound") == 1)
        {
            PlayerPrefs.SetInt("isSound", 0);
            soundButtonImage.sprite = muteImage;
        }
        else if (PlayerPrefs.GetInt("isSound") == 0)
        {
            PlayerPrefs.SetInt("isSound", 1);
            soundButtonImage.sprite = soundImage;
        }
    }

    public void OnClickResetProgress()
    {
        PlayerPrefs.SetInt("levelsCompleted", 0);
    }
}
