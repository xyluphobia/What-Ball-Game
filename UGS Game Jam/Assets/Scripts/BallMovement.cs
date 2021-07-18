using UnityEngine;
using UnityEngine.Events;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool movementEnabled;
    [SerializeField] private float resetYLevel;

    public UnityEvent OnReset;

    private PlayerInput _pi;
    private Rigidbody _rb;

    private void Awake()
    {
        _pi = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.maxAngularVelocity = Mathf.Infinity;
        playerCamera = FindObjectOfType<BallCameraMovement>().transform.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (_pi.Forward && movementEnabled)
            _rb.AddTorque(playerCamera.transform.right * moveSpeed * Time.deltaTime);

        if (_pi.Left && movementEnabled)
            _rb.AddTorque(playerCamera.transform.forward * moveSpeed * Time.deltaTime);

        if (_pi.Back && movementEnabled)
            _rb.AddTorque(-playerCamera.transform.right * moveSpeed * Time.deltaTime);

        if (_pi.Right && movementEnabled)
            _rb.AddTorque(-playerCamera.transform.forward * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        if (transform.position.y <= resetYLevel)
        {
            GameManager.Instance.ResetLevel();
            OnReset?.Invoke();
        }
    }

    private void OnEnable()
    {
        GameManager.UpdateBallStartPosition();
    }
}