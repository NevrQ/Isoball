using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button resumeButton;
    public Ball ballController;

    void Start()
    {
        Time.timeScale = 0f;

        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGame);
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        ballController.StartMoving();
        ballController.ResetStartTime();
        resumeButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame();
    }
}
