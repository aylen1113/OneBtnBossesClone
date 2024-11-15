using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    bool canChangeTime = true;

    [Header("PANELS")]
  public GameObject gameOverPanel;
   public GameObject victoryPanel;

    [Header("OTHER SCRIPTS")]
    public ScoreManager scoreManager;

    [Header("TIME")]
    [SerializeField] GameObject informationPanel;
    [SerializeField] TMP_Text textTime;
    public float time;



    private void Start()
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    void Update()
    {
        Timer();
    }




    private void Timer()
    {
        if (canChangeTime)
        {
            time += Time.deltaTime;
            textTime.text = time.ToString("0.0");
        }
    }


    public void activatePanel(GameObject panel)
    {
        canChangeTime = false;
        
        panel.SetActive(true);
    }


    public void Win()
    {
        activatePanel(victoryPanel);
        scoreManager.HighScoreUpdate();


        float finalTime = time; 
        float bestTime = PlayerPrefs.GetFloat("SavedHighScore");

        textTime.text = $"TIME: {finalTime:0.0} SECONDS\nBEST TIME: {bestTime:0.0} SECONDS";

        textTime.transform.SetParent(informationPanel.transform);
    }
}