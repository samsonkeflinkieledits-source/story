
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Mouse Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 80f;

    [Header("References")]
    public DialogueManager dialogueManager;
    public Challenge challengeStart;

    private float verticalRotation = 0f;

    void Update()
    {
        if (challengeStart != null &&
            challengeStart.IsChallengeActive())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        if (dialogueManager != null &&
            dialogueManager.IsDialogueActive())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        MovePlayer();
        LookAround();
    }

    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * x +
                           transform.forward * z;

        transform.position += movement.normalized *
                              moveSpeed * Time.deltaTime;
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") *
                       mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") *
                       mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(
            verticalRotation, -maxLookAngle, maxLookAngle);

        playerCamera.localRotation =
            Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
