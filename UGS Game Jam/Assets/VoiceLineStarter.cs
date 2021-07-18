using UnityEngine;

public class VoiceLineStarter : MonoBehaviour
{
    private enum PlayMethod { OnStart, ManualTrigger, OnTrigger }

    [SerializeField] private PlayMethod playerMethod;
    [SerializeField] private string voiceLineName;

    void Start()
    {
        if (playerMethod == PlayMethod.OnStart)
            AudioManager.Instance.PlayVoiceLine(voiceLineName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerMethod == PlayMethod.OnTrigger)
            AudioManager.Instance.PlayVoiceLine(voiceLineName);
    }

    public void TriggerVoiceLine()
    {
        if (playerMethod == PlayMethod.ManualTrigger)
            AudioManager.Instance.PlayVoiceLine(voiceLineName);
    }

    public void PlayRandomFinish()
    {
        AudioManager.Instance.PlayRandomFinishMessage();
    }
}
