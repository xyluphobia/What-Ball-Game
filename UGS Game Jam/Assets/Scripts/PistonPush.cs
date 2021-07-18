using Skypex.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonPush : MonoBehaviour
{
    [SerializeField] private float time = .5f;
    [SerializeField] private float artificialForce = 5f;

    private Vector3 _startPosition;
    private Vector3 _vel = Vector3.one;
    private bool _isActive = false;

    private void Start() => _startPosition = transform.localPosition;

    private void Update()
    {
        if (_isActive)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, _startPosition.Add(y: + .5f), ref _vel, time);

            if (transform.localPosition.y >= _startPosition.y + .49f)
                _isActive = false;
        }

        if (!_isActive)
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, _startPosition, ref _vel, time / 3);
    }

    private void OnTriggerStay(Collider collider)
    {
        _isActive = true;
        collider.GetComponent<Rigidbody>().AddForce(transform.forward * artificialForce);
    }
}
