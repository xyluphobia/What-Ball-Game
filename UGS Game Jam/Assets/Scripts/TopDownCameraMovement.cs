using Skypex.Raycasting;
using Skypex.ExtensionMethods;
using UnityEngine;

public class TopDownCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTrack;
    [Space]
    [SerializeField] private float cameraDistance;
    [SerializeField, Range(10f, 50f)] private float cameraSpeed = 10f;
    [SerializeField, Range(50f, 500f)] private float zoomSpeed = 10f;
    [SerializeField, Range(.1f, 10f)] private float sensitivity;
    [SerializeField] private Vector3 velocity = Vector3.one;
    [SerializeField] private float smoothTime = .5f;
    [SerializeField] private bool invertY = false;

    private PlayerInput _pi;
    private Rigidbody _rb;
    private int _cameraInvertValue;

    private void Awake()
    {
        _pi = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start() => UpdateCameraDistance();

    private void FixedUpdate()
    {
        UpdateCameraDistance();

        if (_pi.Any)
            Move();

        Zoom();
    }

    private void Update()
    {
        _cameraInvertValue = GetInvertValue();

        //MOUSE
        transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        transform.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * sensitivity * _cameraInvertValue);
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_pi.Left.ToInt() - _pi.Right.ToInt(), _pi.Back.ToInt() - _pi.Forward.ToInt()).normalized;

        transform.Translate(direction.x * cameraSpeed * Time.deltaTime, direction.y * cameraSpeed * Time.deltaTime, 0f);
        //direction.y* cameraSpeed *Time.deltaTime
    }

    private void Zoom()
    {
        cameraDistance += -_pi.ScrollWheelDelta * zoomSpeed * Time.deltaTime;
    }

    private int GetInvertValue() => invertY ? 1 : -1;

    private void UpdateCameraDistance()
    {
        Raycast.Single(transform.position, Vector3.down, out RaycastHit hitInfo, cameraDistance * 2);

        Vector3 targetPosition = transform.position.With(y: hitInfo.point.y + cameraDistance);

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = smoothedPosition;
    }
}
