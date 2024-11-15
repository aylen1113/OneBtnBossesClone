using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool isGameActive = true;

    void Start()
    
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (isGameActive)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void StopTimer()
    {
        isGameActive = false;
    }
}
