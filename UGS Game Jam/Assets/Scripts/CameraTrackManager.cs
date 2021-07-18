using UnityEngine;
using UnityEngine.Animations;

public class CameraTrackManager : MonoBehaviour
{
    #region Singleton
    public static CameraTrackManager _instance;

    public static CameraTrackManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    #endregion

    private ParentConstraint _parentConstraint;

    public void ConstrainCamera()
    {
        _parentConstraint = GetComponent<ParentConstraint>();
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = FindObjectOfType<BallMovement>().transform;
        _parentConstraint.AddSource(source);
    }
}
