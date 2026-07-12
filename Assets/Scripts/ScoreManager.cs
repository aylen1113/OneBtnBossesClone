using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TMP_Text highScoreText;
    [SerializeField] GameObject bestTimePanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void HighScoreUpdate()
    {
        float currentTime = GameManager.Instance.time;

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

        highScoreText.text =
            $"BEST TIME: {PlayerPrefs.GetFloat("SavedHighScore"):0.0} SECONDS";
    }
}