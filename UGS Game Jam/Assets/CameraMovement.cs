using Skypex.ExtensionMethods;
using Skypex.EditorFunctions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTrack;
    [SerializeField] private float cameraDistance = 12f;
    [Space]
    [SerializeField, Range(.1f, 10f)] private float sensitivity = 1;
    [SerializeField] private bool invertY = false;

    private int cameraInvertValue;

    private void Start()
    {
        UpdateCameraDistance();
    }

    private void Update()
    {
        UpdateCameraDistance();

        transform.LookAt(cameraTrack);

        cameraInvertValue = GetInvertValue();

        //MOUSE
        cameraTrack.RotateAround(cameraTrack.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        cameraTrack.RotateAround(cameraTrack.position, cameraTrack.right, Input.GetAxis("Mouse Y") * sensitivity * cameraInvertValue);
    }

    private int GetInvertValue() => invertY ? 1 : -1;

    private void UpdateCameraDistance() => transform.localPosition = transform.localPosition.With(z: -cameraDistance);
}
