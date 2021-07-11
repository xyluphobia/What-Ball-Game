using Skypex.ExtensionMethods;
using Skypex.Raycasting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTrack;
    [Space]
    [SerializeField] private float cameraDistance = 12f;
    [SerializeField] private float smoothTime = .5f;
    [SerializeField] private float _velocity = 1f;
    [SerializeField, Range(.1f, 10f)] private float sensitivity = 1;
    [SerializeField] private bool invertY = false;

    private int _cameraInvertValue;

    private void Awake()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        CheckCameraBlock();

        transform.LookAt(cameraTrack);

        _cameraInvertValue = GetInvertValue();

        //MOUSE
        cameraTrack.RotateAround(cameraTrack.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        cameraTrack.RotateAround(cameraTrack.position, cameraTrack.right, Input.GetAxis("Mouse Y") * sensitivity * _cameraInvertValue);
    }

    private int GetInvertValue() => invertY ? 1 : -1;

    private void UpdateCameraDistance(float distance)
    {
        transform.localPosition = transform.localPosition.With(z: -distance);
    }

    private void CheckCameraBlock()
    {
        if (Raycast.Single(cameraTrack.position, transform.position, out RaycastHit hitInfo, cameraDistance + 1f))
        {
            float dampDistance = Mathf.SmoothDamp(cameraDistance, hitInfo.distance, ref _velocity, smoothTime);
            Debug.Log(dampDistance);
            UpdateCameraDistance(dampDistance);
        }
    }
}