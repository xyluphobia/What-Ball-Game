using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Transform ballCamTransform;
    [SerializeField] private Transform topDownCamTransform;
    [SerializeField] private BallMovement playerBall;

    private Camera _mainCam;
    private Camera _ballCam;
    private Camera _topDownCam;
    private PlayerInput _pi;

    private void Awake()
    {
        _mainCam = GetComponent<Camera>();
        _ballCam = ballCamTransform.GetComponent<Camera>();
        _topDownCam = topDownCamTransform.GetComponent<Camera>();
        _pi = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _mainCam.enabled = true;
        _ballCam.enabled = false;
        _topDownCam.enabled = false;

        ballCamTransform.gameObject.SetActive(false);
        topDownCamTransform.gameObject.SetActive(true);

        playerBall.enabled = false;

        Debug.Log("Press 'Return' to change camera. (Editor Only)");
    }

    public void SwitchCamera(bool useBallCam)
    {
        if (useBallCam)
        {
            transform.SetParent(ballCamTransform);
            ResetTransform();
            _mainCam = _ballCam;
            playerBall.enabled = true;
            ballCamTransform.gameObject.SetActive(true);
            topDownCamTransform.gameObject.SetActive(false);
            return;
        }

        transform.SetParent(topDownCamTransform);
        ResetTransform();
        _mainCam = _topDownCam;
        playerBall.enabled = false;
        ballCamTransform.gameObject.SetActive(false);
        topDownCamTransform.gameObject.SetActive(true);
    }

    private void ResetTransform()
    {
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }
}
