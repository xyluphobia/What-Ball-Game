using Skypex.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
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

    private void FixedUpdate()
    {
        if (_pi.Forward && movementEnabled)
            _rb.AddTorque(playerCamera.transform.right * moveSpeed);

        if (_pi.Left && movementEnabled)
            _rb.AddTorque(playerCamera.transform.forward * moveSpeed);

        if (_pi.Back && movementEnabled)
            _rb.AddTorque(-playerCamera.transform.right * moveSpeed);

        if (_pi.Right && movementEnabled)
            _rb.AddTorque(-playerCamera.transform.forward * moveSpeed);
    }
}