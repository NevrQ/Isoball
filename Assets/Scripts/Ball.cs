using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialMoveSpeed = 5f;
    public float boostedSpeed = 10f;
    public float decelerationRate = 0.1f;

    private Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartMoving();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 decelerationForce = -rb.velocity.normalized * decelerationRate;
            rb.AddForce(decelerationForce, ForceMode.Acceleration);
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        rb.velocity = transform.forward * initialMoveSpeed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
        isMoving = false;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        if (isMoving)
        {
            rb.velocity = direction.normalized * initialMoveSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            initialMoveSpeed = boostedSpeed;
            SetMoveDirection(rb.velocity.normalized);
        }
    }
}
