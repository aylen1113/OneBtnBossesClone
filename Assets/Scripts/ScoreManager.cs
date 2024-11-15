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
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (manager.time * 10 < PlayerPrefs.GetFloat("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", manager.time * 10);
                bestTimePanel.SetActive(true);
            }

        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", manager.time * 10);
        }

        highScoreText.text = PlayerPrefs.GetFloat("SavedHighScore").ToString("0");
    }
}