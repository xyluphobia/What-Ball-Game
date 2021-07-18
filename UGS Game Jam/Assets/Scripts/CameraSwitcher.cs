using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Transform ballCamTransform;
    [SerializeField] private Transform topDownCamTransform;

    private BallMovement _playerBall;
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
        _playerBall = GameManager.PlayerBall.GetComponent<BallMovement>();

        _mainCam.enabled = true;
        _ballCam.enabled = false;
        _topDownCam.enabled = false;

        ballCamTransform.gameObject.SetActive(false);
        topDownCamTransform.gameObject.SetActive(true);

        _playerBall.enabled = false;

        Debug.Log("Press 'Return' to change camera. (Editor Only)");
    }

    public void SwitchCamera(bool useBallCam)
    {
        if (useBallCam)
        {
            transform.SetParent(ballCamTransform);
            ResetTransform();
            _mainCam = _ballCam;
            _playerBall.enabled = true;
            ballCamTransform.gameObject.SetActive(true);
            topDownCamTransform.gameObject.SetActive(false);
            return;
        }

        transform.SetParent(topDownCamTransform);
        ResetTransform();
        _mainCam = _topDownCam;
        _playerBall.enabled = false;
        ballCamTransform.gameObject.SetActive(false);
        topDownCamTransform.gameObject.SetActive(true);
    }

    private void ResetTransform()
    {
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }
}
