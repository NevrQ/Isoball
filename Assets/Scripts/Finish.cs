using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject victoryScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            victoryScreen.SetActive(true);
        }
    }
}
