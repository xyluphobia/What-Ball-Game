using Skypex.ExtensionMethods;
using UnityEngine;

public class BallCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerBall;
    [SerializeField] private Transform cameraTrack;
    [Space]
    [SerializeField] private float startingCameraDistance = 12f;
    [SerializeField] private float minCameraDistance = 1f;
    [SerializeField] private float maxCameraDistance = 20f;
    [SerializeField] private float smoothTime = .5f;
    [SerializeField, Range(.1f, 10f)] private float sensitivity = 1;
    [SerializeField] private bool invertY = false;

    private int _cameraInvertValue;
    private float _currentCameraDistance;
    private RaycastHit hitInfo;
    private float _velocity = 1f;

    private void Start()
    {
        _currentCameraDistance = startingCameraDistance;
        ClampCameraLookAngle();
        throw new System.NotImplementedException("Check Camera Block Not implemented properly");
    }

    private void Update()
    {
        CheckCameraIsBlocked();

        transform.LookAt(cameraTrack);

        _cameraInvertValue = GetInvertValue();

        //MOUSE
        cameraTrack.RotateAround(cameraTrack.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        cameraTrack.RotateAround(cameraTrack.position, cameraTrack.right, Input.GetAxis("Mouse Y") * sensitivity * _cameraInvertValue);
    }

    private int GetInvertValue() => invertY ? 1 : -1;

    private void UpdateCameraDistance(float targetDistance)
    {
        if (targetDistance > maxCameraDistance)
            return;

        targetDistance.MinMax(minCameraDistance, maxCameraDistance); //Clamp camera distance
        float dampDistance = Mathf.SmoothDamp(_currentCameraDistance, targetDistance, ref _velocity, smoothTime);

        transform.localPosition = transform.localPosition.With(z: -dampDistance);
    }

    private void CheckCameraIsBlocked()
    {
        Ray ray = new Ray();
        ray.origin = playerBall.position;
        ray.direction = transform.position;
        if (Physics.Raycast(ray, out hitInfo, _currentCameraDistance + 1f))
        {
            UpdateCameraDistance(hitInfo.distance - 1f);
        }
    }

    private void ClampCameraLookAngle()
    {
        throw new System.NotImplementedException("Clamping not implemented");
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(cameraTrack.position, hitInfo.point);
    }
}