using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{
    public UnityEvent OnFinish;

    private void OnTriggerEnter(Collider other)
    {
        OnFinish?.Invoke();
        SceneLoader.LoadNextScene();
    }
}
