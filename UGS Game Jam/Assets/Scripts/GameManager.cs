using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ToggleCursor();
    }

    private void ToggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Cursor Locked");
            return;
        }

        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Cursor Unlocked");
    }
}
