using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   
    public GameManager manager;

   
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] GameObject bestTimePanel;


    public void HighScoreUpdate()
    {
        float currentTime = manager.time; 

        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (currentTime < PlayerPrefs.GetFloat("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", currentTime);
                bestTimePanel.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", currentTime);
        }

        highScoreText.text = $"BEST TIME: {PlayerPrefs.GetFloat("SavedHighScore"):0.0} SECONDS";
    }
}