using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager _instance;

    public static GameManager Instance => _instance;

    private void CreateSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    #endregion

    [SerializeField] private AudioManager audioManager;
    [Space]
    [SerializeField] private List<GameObject> DontDestroyOnLoadObjects = new List<GameObject>();

    public static GameObject PlayerBall => _playerBall;

    private static Vector3 _ballStartPos;
    private static GameObject _playerBall;

    private void Awake()
    {
        CreateSingleton();
        _playerBall = FindObjectOfType<BallMovement>().gameObject;

        foreach (GameObject obj in DontDestroyOnLoadObjects)
            DontDestroyOnLoad(obj);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        PlayRandomMusic();
        UpdateBallStartPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleCursor();
    }

    private void ToggleCursor()
    {        
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    public void ResetLevel()
    {
        _playerBall.transform.position = _ballStartPos;
        _playerBall.transform.rotation = Quaternion.identity;
        Rigidbody rb =_playerBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    //public void NextLevel(Scene s1, Scene s2)
    //{
    //    UpdateBallStartPosition();

    //    _playerBall.transform.position = _ballStartPos;
    //    _playerBall.transform.rotation = Quaternion.identity;
    //    Rigidbody rb = _playerBall.GetComponent<Rigidbody>();
    //    rb.velocity = Vector3.zero;
    //    rb.angularVelocity = Vector3.zero;
    //}

    public static void UpdateBallStartPosition()
    {
        _playerBall = FindObjectOfType<BallMovement>().gameObject;
        _ballStartPos = _playerBall.transform.position;
    }

    public void PlayRandomMusic()
    {
        string songName = "Nature Song";
        int rndNum = Random.Range(0, 2);
        if (rndNum == 0)
            songName = "Nature Song";
        else if (rndNum == 1)
            songName = "Spacetime Vibing";

        audioManager.PlayMusic(songName);
    }

    public void PlayMusic(string songName) => audioManager.PlayMusic(songName);
}