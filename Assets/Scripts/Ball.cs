using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float initialMoveSpeed = 5f;
    public float boostedSpeed = 10f;
    public float decelerationRate = 0.1f;
    private Rigidbody rb;
    private bool isMoving = false;
    private float startTime;
    private float restartDelay = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 decelerationForce = -rb.velocity.normalized * decelerationRate;
            rb.AddForce(decelerationForce, ForceMode.Acceleration);
        }

        CheckSpeed();
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

    public void ResetStartTime()
    {
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Boost"))
        {
            Boost();
        }
    }

    private void Boost()
    {
        rb.velocity = rb.velocity.normalized * boostedSpeed;
    }

    private void CheckSpeed()
    {
        if (Time.time >= startTime + restartDelay && rb.velocity.magnitude < 0.1f)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
