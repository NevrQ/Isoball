using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialMoveSpeed = 5f;
    public float decelerationRate = 0.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * initialMoveSpeed;
    }

    void FixedUpdate()
    {
        Vector3 decelerationForce = -rb.velocity.normalized * decelerationRate;

        rb.AddForce(decelerationForce, ForceMode.Acceleration);
    }
}
