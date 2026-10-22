using TMPro;
using UnityEngine;

public class DIalogueNPC : MonoBehaviour
{
   
    public DialogueManager dialogueManager;
    public GameTimer gameTimer;

    [Header("Shared Interaction Prompt")]
    public TMP_Text interactionText;

    [Header("Timer Settings")]
    public bool startsTimer = false;

    [TextArea(2, 5)]
    public string[] dialogueLines =
    {
        "Hello there!",
        "I have something to tell you.",
        "Good luck on your journey!"
    };

    private bool playerInRange;
    private static DIalogueNPC currentNPC;

    void Start()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Only the selected NPC controls the shared prompt.
        if (currentNPC != this)
            return;

        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(
                playerInRange &&
                dialogueManager != null &&
                !dialogueManager.IsDialogueActive()
            );
        }

        if (playerInRange &&
            Input.GetKeyDown(KeyCode.E) &&
            dialogueManager != null &&
            !dialogueManager.IsDialogueActive())
        {
            if (interactionText != null)
                interactionText.gameObject.SetActive(false);

            dialogueManager.StartDialogue(dialogueLines);

            if (startsTimer && gameTimer != null)
                gameTimer.StartTimer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            currentNPC = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (currentNPC == this)
            {
                currentNPC = null;

                if (interactionText != null)
                    interactionText.gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        if (currentNPC == this)
        {
            currentNPC = null;

            if (interactionText != null)
                interactionText.gameObject.SetActive(false);
        }
    }
}