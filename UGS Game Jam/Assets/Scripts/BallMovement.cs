using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool movementEnabled;

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
}