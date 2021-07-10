using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public bool Forward;
    [HideInInspector] public bool Left;
    [HideInInspector] public bool Back;
    [HideInInspector] public bool Right;
    [HideInInspector] public bool Any;

    private void Update()
    {
        //WASD DOWN
        if (Input.GetKeyDown(KeyCode.W))
            Forward = true;

        if (Input.GetKeyDown(KeyCode.A))
            Left = true;

        if (Input.GetKeyDown(KeyCode.S))
            Back = true;

        if (Input.GetKeyDown(KeyCode.D))
            Right = true;

        //WASD UP
        if (Input.GetKeyUp(KeyCode.W))
            Forward = false;

        if (Input.GetKeyUp(KeyCode.A))
            Left = false;

        if (Input.GetKeyUp(KeyCode.S))
            Back = false;

        if (Input.GetKeyUp(KeyCode.D))
            Right = false;

        //WASD ANY
        if (Forward || Left || Back || Right)
            Any = true;

        if (!Forward && !Left && !Back && !Right)
            Any = false;
    }
}
