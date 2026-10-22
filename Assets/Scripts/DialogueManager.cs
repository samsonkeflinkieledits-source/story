using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel; // Assign the new dialogue-only panel
    public TMP_Text dialogueText;
    public Button continueButton;
    public GameTimer gameTimer;

    private string[] dialogueLines;
    private int currentLine;
    private bool dialogueActive;

    void Start()
    {
        dialoguePanel.SetActive(false);
        continueButton.onClick.AddListener(NextLine);
        LockCursor();
    }

    public void StartDialogue(string[] lines, bool startTimer = false)
    {
        if (lines == null || lines.Length == 0)
            return;

        dialogueLines = lines;
        currentLine = 0;
        dialogueActive = true;

        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Only start the timer when the NPC requests it.
        if (startTimer && gameTimer != null)
        {
            gameTimer.StartTimer();
        }
    }

    public void NextLine()
    {
        if (!dialogueActive)
            return;

        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            dialogueActive = false;
            dialoguePanel.SetActive(false);
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }
}