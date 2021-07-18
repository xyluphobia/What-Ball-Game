using Skypex.ExtensionMethods;
using UnityEngine;

public class BallCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTrack;
    [Space]
    [SerializeField] private float cameraDistance = 12f;
    [SerializeField] private float viewRange = 85f;
    [SerializeField] private float minCameraDistance = 1f;
    [SerializeField, Range(.1f, 10f)] private float sensitivity = 1;
    [SerializeField] private bool invertY = false;

    private int _cameraInvertValue;
    private float _currentCameraDistance;
    private RaycastHit hitInfo;
    private Quaternion _cameraRotation;

    private void OnEnable()
    {
        _currentCameraDistance = cameraDistance;
        _cameraRotation = cameraTrack.localRotation;
    }

    private void Update()
    {
        CheckCameraIsBlocked();

        transform.LookAt(cameraTrack.position + Vector3.up / 2);

        _cameraInvertValue = GetInvertValue();

        //Camera Rotation
        _cameraRotation.x -= Input.GetAxis("Mouse Y") * sensitivity;
        _cameraRotation.y -= Input.GetAxis("Mouse X") * sensitivity * _cameraInvertValue;

        _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, -viewRange, viewRange);

        cameraTrack.localRotation = Quaternion.Euler(_cameraRotation.x, _cameraRotation.y, _cameraRotation.z);
    }

    private int GetInvertValue() => invertY ? 1 : -1;

    private void UpdateCameraDistance(float targetDistance)
    {
        if (targetDistance > cameraDistance)
            return;

        _currentCameraDistance = targetDistance.Min(minCameraDistance); //Clamp camera distance
        //float dampDistance = Mathf.SmoothDamp(_currentCameraDistance, targetDistance, ref _velocity, smoothTime);

        transform.localPosition = transform.localPosition.With(z: -_currentCameraDistance);
    }

    private void CheckCameraIsBlocked()
    {
        if (Physics.Raycast(cameraTrack.position, cameraTrack.position.DirectionTo3D(transform.position), out hitInfo))
        {
            UpdateCameraDistance(hitInfo.distance - 1f);
            return;
        }

        UpdateCameraDistance(cameraDistance);
    }
}