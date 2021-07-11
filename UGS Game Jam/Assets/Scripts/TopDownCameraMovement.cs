using Skypex.Raycasting;
using Skypex.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTrack;
    [Space]
    [SerializeField] private float cameraDistance;
    [SerializeField, Range(.01f, .5f)] private float cameraSpeed = 1f;
    [SerializeField, Range(.1f, 10f)] private float sensitivity;
    [SerializeField] private Vector3 velocity = Vector3.one;
    [SerializeField] private float smoothTime = .5f;
    [SerializeField] private bool invertY = false;

    private PlayerInput _pi;
    private int _cameraInvertValue;

    private void Awake() => _pi = GetComponent<PlayerInput>();

    private void Start() => UpdateCameraDistance();

    private void FixedUpdate() => UpdateCameraDistance();

    private void Update()
    {
        _cameraInvertValue = GetInvertValue();

        //MOUSE
        transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        transform.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * sensitivity * _cameraInvertValue);

        if (_pi.Any)
            Move();
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_pi.Left.ToInt() - _pi.Right.ToInt(), _pi.Back.ToInt() - _pi.Forward.ToInt()).normalized;
        transform.Translate(new Vector3(direction.x * cameraSpeed, direction.y * cameraSpeed, 0f));
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
