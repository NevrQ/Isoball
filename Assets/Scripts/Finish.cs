using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject victoryScreen;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (victoryScreen != null)
            {
                victoryScreen.SetActive(true);
            }
        }
    }
}
