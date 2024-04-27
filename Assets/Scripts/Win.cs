using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private MeshRenderer cubeRenderer;
    [SerializeField] private Color color1;
    [SerializeField] private Color color2;

    private void Start()
    {
        Destroy(GameObject.Find("MusicManager(Clone)"));
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.GetInt("isSound") == 0)
            AudioListener.volume = 0;
    }

    void FixedUpdate()
    {
        cube.transform.Rotate(new Vector3(0.1f, 0, 0.5f));

        cubeRenderer.material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 3));
        if (Random.Range(0, 200) == 0)
        {
            color1 = color2;
            color2 = Random.ColorHSV();
        }
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
