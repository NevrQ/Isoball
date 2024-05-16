using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialMoveSpeed = 5f;
    public float decelerationRate = 0.1f;

    private Rigidbody rb;
    private bool isMoving = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * initialMoveSpeed;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 decelerationForce = -rb.velocity.normalized * decelerationRate;

            rb.AddForce(decelerationForce, ForceMode.Acceleration);
        }
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
        isMoving = false;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        if (!isMoving)
        {
            isMoving = true;
            rb.velocity = direction.normalized * initialMoveSpeed;
        }
    }
}
