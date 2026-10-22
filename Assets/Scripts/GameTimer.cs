
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public int loseSceneBuildIndex = 1;

    [SerializeField] public float timeRemaining = 180f; 
    private bool timerRunning = false;

    void Start()
    {
        timerText.gameObject.SetActive(false);
    }

    public void StartTimer()
    {
        if (timerRunning)
            return;

        timeRemaining = 180f;
        timerRunning = true;

        timerText.gameObject.SetActive(true);
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            timerRunning = false;

            SceneManager.LoadScene(loseSceneBuildIndex);
            return;
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}