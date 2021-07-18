using UnityEngine;
using UnityEngine.Events;

public class LoadNextSceneTrigger : MonoBehaviour
{
    public UnityEvent OnLoadNextSceneTrigger;

    private void OnTriggerEnter(Collider other) => OnLoadNextSceneTrigger?.Invoke();
}
