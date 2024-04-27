using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeStart;
    [SerializeField] private Text timerText;
    [SerializeField] private Text InstructionText;
    [SerializeField] private Text InstructionText1;
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        timerText.text = timeStart.ToString();
        InstructionText.enabled = true;
        InstructionText1.enabled = false;
        timerText.enabled = true;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.H))
            timeStart = 0;
#endif
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            timerText.text = Mathf.Round(timeStart).ToString();
        }
        else if (timeStart <= 0 && playerTransform.position.y > 10) 
        {
            InstructionText.enabled = false;
            InstructionText1.enabled = true;
            timerText.enabled = false;
            playerTransform.position = new Vector3(0, 2, 0);
        }
    }
}
