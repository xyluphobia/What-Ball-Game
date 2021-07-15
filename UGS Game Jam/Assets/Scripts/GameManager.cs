using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [Space]
    [SerializeField] private List<GameObject> DontDestroyOnLoadObjects = new List<GameObject>();

    private void Awake()
    {
        foreach (GameObject obj in DontDestroyOnLoadObjects)
            DontDestroyOnLoad(obj);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        audioManager.PlayMusic("Nature Song");
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