using Skypex.ExtensionMethods;
using System;
using System.Collections;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float time = 3f;

    private bool _moveForward = true;
    private float _startingX;

    private void OnEnable() => _startingX = transform.localPosition.x;

    private void FixedUpdate()
    {
        if (_moveForward)
            MoveOver();

        if (!_moveForward)
            MoveBack();
    }

    private void MoveOver()
    {
        transform.localPosition = transform.localPosition.With(x: transform.localPosition.x - 3 / (time * 75));

        if (transform.localPosition.x < _startingX - 2f)
        {
            transform.localPosition = transform.localPosition.With(x: _startingX - 2f);
            _moveForward = false;
        }
    }

    private void MoveBack()
    {
        transform.localPosition = transform.localPosition.With(x: transform.localPosition.x + 3 / (time * 75));

        if (transform.localPosition.x > _startingX)
        {
            transform.localPosition = transform.localPosition.With(x: _startingX);
            _moveForward = true;
        }
    }
}
