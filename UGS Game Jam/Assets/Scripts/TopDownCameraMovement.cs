using Skypex.Raycasting;
using Skypex.ExtensionMethods;
using UnityEngine;

public class TopDownCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTrack;
    [Space]
    [SerializeField, Range(5f, 20f)] private float cameraSpeed = 10f;
    [SerializeField, Range(.1f, 10f)] private float sensitivity;
    [SerializeField] private float viewRange = 85f;
    [SerializeField] private bool invertY = false;

    private PlayerInput _pi;
    private int _cameraInvertValue;
    private Quaternion _cameraRotation;

    private void Awake()
    {
        _pi = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _cameraRotation = transform.localRotation;
    }

    private void Update()
    {
        _cameraInvertValue = GetInvertValue();

        if (_pi.Any)
            Move();

        //Camera Rotation
        _cameraRotation.x -= Input.GetAxis("Mouse Y") * sensitivity;
        _cameraRotation.y -= Input.GetAxis("Mouse X") * sensitivity * _cameraInvertValue;

        _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, -viewRange, viewRange);

        transform.localRotation = Quaternion.Euler(_cameraRotation.x, _cameraRotation.y, _cameraRotation.z);
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_pi.Left.ToInt() - _pi.Right.ToInt(), _pi.Down.ToInt() - _pi.Up.ToInt(), _pi.Back.ToInt() - _pi.Forward.ToInt()).normalized;

        transform.Translate(direction.x * cameraSpeed * Time.deltaTime, 0f, direction.z * cameraSpeed * Time.deltaTime);
        transform.Translate(0f, direction.y * cameraSpeed * Time.deltaTime, 0f, Space.World);
    }

    private int GetInvertValue() => invertY ? 1 : -1;
}
