using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public GameObject startButton;
    private bool gameStarted = false;

    public void StartGame()
    {
        startButton.SetActive(false);
        gameStarted = true;
    }
}
