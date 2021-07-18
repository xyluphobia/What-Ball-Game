using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    void Start() => transform.localEulerAngles = new Vector3(Random.Range(0, 4) * 90, Random.Range(0, 4) * 90, Random.Range(0, 4) * 90);
}
