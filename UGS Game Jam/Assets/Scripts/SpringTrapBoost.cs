using UnityEngine;

public class SpringTrapBoost : MonoBehaviour
{
    [SerializeField, Range(500f, 2500f)] private float force = 10;

    private void OnTriggerEnter(Collider other) => other.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up).normalized * force);
}