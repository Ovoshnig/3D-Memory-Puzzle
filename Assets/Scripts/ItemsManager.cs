using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private ItemController[] items;
    [SerializeField] private AudioSource levelUpSource;
    [SerializeField] private Arm arm;

    private int equalCount = 0;
    private bool alreadyPlayed = false;

    void Update()
    {
        if (items.Length != equalCount)
            equalCount = 0;
        foreach (ItemController item in items)
        {
            if (item.IsEqual)
                equalCount++;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.J))
            equalCount = items.Length;
#endif
        if (items.Length == equalCount && !arm.IsItemSelected)
        {
            if (!alreadyPlayed)
            {
                if (PlayerPrefs.GetInt("levelsCompleted") < SceneManager.GetActiveScene().buildIndex)
                    PlayerPrefs.SetInt("levelsCompleted", SceneManager.GetActiveScene().buildIndex);
                levelUpSource.Play();
                alreadyPlayed = true;
            }
            if (!levelUpSource.isPlaying)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
