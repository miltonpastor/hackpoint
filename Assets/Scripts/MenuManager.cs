using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Methods to show and hide the game over panel
    public void ShowGameOverPanel() { gameOverPanel.SetActive(true); }
    public void HideGameOverPanel() { gameOverPanel.SetActive(false); }

    public void ShowLevelCompletePanel() { levelCompletePanel.SetActive(true); }
    public void HideLevelCompletePanel() { levelCompletePanel.SetActive(false); }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
