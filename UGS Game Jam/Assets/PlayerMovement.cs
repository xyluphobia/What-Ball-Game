using Skypex.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float moveSpeed;

    private PlayerInput _pi;
    private Rigidbody _rb;

    private void Awake()
    {
        _pi = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_pi.Forward)
            _rb.AddTorque(playerCamera.transform.right * moveSpeed);

        if (_pi.Left)
            _rb.AddTorque(playerCamera.transform.forward * moveSpeed);

        if (_pi.Back)
            _rb.AddTorque(-playerCamera.transform.right * moveSpeed);

        if (_pi.Right)
            _rb.AddTorque(-playerCamera.transform.forward * moveSpeed);
    }
}