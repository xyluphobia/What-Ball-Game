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
    [SerializeField, Range(.1f, 10f)] private float sensitivity = 1;
    [SerializeField] private bool invertY = false;

    private int _cameraInvertValue;

    private void Start()
    {
        ClampCamera();
        throw new NotImplementedException("Check Camera Block Not implemented properly");
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
        float preferredDistance = cameraDistance;
        if (Raycast.Single(cameraTrack.position, transform.position, out RaycastHit hitInfo, cameraDistance + 5f))
        {
            float lerpDistance = Mathf.Lerp(cameraDistance, hitInfo.distance - 2f, smoothTime);
            Debug.Log(lerpDistance);
            preferredDistance = lerpDistance;
        }

        UpdateCameraDistance(preferredDistance);
    }

    private void ClampCamera()
    {
        throw new NotImplementedException("Clamping not implemented");
    }
}