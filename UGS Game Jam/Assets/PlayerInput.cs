using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool Forward;
    public bool Left;
    public bool Back;
    public bool Right;

    private void Update()
    {
        //WASD DOWN
        if (Input.GetKeyDown(KeyCode.W))
        {
            Forward = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Left = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Back = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Right = true;
        }

        //WASD UP
        if (Input.GetKeyUp(KeyCode.W))
        {
            Forward = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Left = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Back = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Right = false;
        }
    }
}
