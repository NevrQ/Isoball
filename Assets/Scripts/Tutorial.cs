using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TMP_Text tutorialText;
    private int currentIndex = 0;

    void Start()
    {
        tutorialPanel.SetActive(false);
    }

    public void StartTutorial()
    {
        currentIndex = 0;
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorialPanel()
    {
        tutorialPanel.SetActive(false);
    }

    public void StartTutorialOnClick()
    {
        StartTutorial();
    }
}
