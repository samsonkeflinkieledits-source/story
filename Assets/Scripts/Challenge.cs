using UnityEngine;

public class Challenge : MonoBehaviour
{
    public GameObject challengePanel;

    private bool challengeActive = true;

    void Awake()
    {
        challengeActive = true;

        if (challengePanel != null)
            challengePanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public bool IsChallengeActive()
    {
        return challengeActive;
    }

    public void YesButton()
    {
        challengeActive = false;
        challengePanel.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void NoButton()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

}
