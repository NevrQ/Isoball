using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text attemptsText;
    private int attempts;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        attempts = 0;
        UpdateAttemptsText();
    }

    public void IncrementAttempts()
    {
        attempts++;
        UpdateAttemptsText();
    }

    void UpdateAttemptsText()
    {
        attemptsText.text = "Attempts: " + attempts;
    }

    public void RestartGame()
    {
        IncrementAttempts();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}