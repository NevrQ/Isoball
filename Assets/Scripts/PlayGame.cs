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
        resumeButton.gameObject.SetActive(false);
    }
}
