using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField, Range(5f, 30f)] private float force = 1;

    private void OnTriggerStay(Collider other) => other.GetComponent<Rigidbody>().AddForce(transform.forward * force);
}
