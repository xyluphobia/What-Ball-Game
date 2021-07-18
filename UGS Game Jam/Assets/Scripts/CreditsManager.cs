using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CreditsManager : MonoBehaviour
{
    [System.Serializable]
    private class Credits
    {
        public string Name;
        public TMP_Text Object;
    }

    [SerializeField] private List<Credits> creditsObjects = new List<Credits>();

    private void OnEnable()
    {
        foreach (var c in creditsObjects)
            c.Object.text = c.Name;
    }
}
