using Skypex.EditorFunctions;
using UnityEngine;

public class SpringTrapBoost : MonoBehaviour
{
    [SerializeField, Range(500f, 2500f)] private float force = 10;

    private void OnTriggerEnter(Collider other) => other.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up).normalized * force);

    private void OnDrawGizmosSelected()
    {
        Draw.Line(Color.blue, transform.position + transform.up / 2, transform.position + transform.forward + transform.up / 2);
    }
}
