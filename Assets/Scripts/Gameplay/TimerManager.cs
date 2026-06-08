using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text timerText;

    [Header("Score Settings")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Timer Settings")]
    private float timeRemaining = 60f;
    private bool isTimerRunning = false;

    public static int PlayerScore { get; set; }

    void Start()
    {
        PlayerScore = 0;
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                DisplayTime(timeRemaining);
                TriggerEndgame();
            }
        }

        scoreText.text = "Score : " + PlayerScore;
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerEndgame()
    {
        SceneManager.LoadScene("Endgame");
    }
}