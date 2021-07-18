using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public bool Forward;
    [HideInInspector] public bool Left;
    [HideInInspector] public bool Back;
    [HideInInspector] public bool Right;
    [HideInInspector] public bool Up;
    [HideInInspector] public bool Down;
    [HideInInspector] public bool Any;

    [HideInInspector] public bool UseBallCam;
    [HideInInspector] public float ScrollWheelDelta;

    public UnityEvent<bool> OnSwitchCamera;
    public UnityEvent<SelectionDirection> OnSelectionChanged;
    public UnityEvent<MouseButton> OnMouseClick;

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
        if (Forward || Left || Back || Right || Up || Down)
            Any = true;

        if (!Forward && !Left && !Back && !Right && !Up && !Down)
            Any = false;

        //SPACE & CTRL
        if (Input.GetKeyDown(KeyCode.Space))
            Up = true;

        if (Input.GetKeyDown(KeyCode.LeftControl))
            Down = true;

        if (Input.GetKeyUp(KeyCode.Space))
            Up = false;

        if (Input.GetKeyUp(KeyCode.LeftControl))
            Down = false;

        //SCROLL SHEEL
        ScrollWheelDelta = Input.mouseScrollDelta.y;

        //MOUSE BUTTONS
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnMouseClick?.Invoke(MouseButton.LeftClick);

        if (Input.GetKeyUp(KeyCode.Mouse1))
            OnMouseClick?.Invoke(MouseButton.RightClick);

        //QE
        if (Input.GetKeyDown(KeyCode.Q))
            OnSelectionChanged?.Invoke(SelectionDirection.Left);

        if (Input.GetKeyDown(KeyCode.E))
            OnSelectionChanged?.Invoke(SelectionDirection.Right);

#if UNITY_EDITOR
        //CAM SWITCH
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UseBallCam ^= true;
            OnSwitchCamera?.Invoke(UseBallCam);
        }
#endif
    }

    public void SetUseBallCam(bool value) => UseBallCam = value;
}

public enum SelectionDirection
{
    Left,
    Right
}

public enum MouseButton
{
    LeftClick,
    RightClick
}