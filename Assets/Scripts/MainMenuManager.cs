using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;

    // Cache the screen bounds to avoid recalculating them every update
    private float screenWidth;
    private float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;

        // Calculate and cache the screen bounds
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsGamePaused())
            {
                ResumeGame();
                print("Resuming game: " + Time.timeScale);
            }
            else
            {
                PauseGame();
                print("Pausing game: " + Time.timeScale);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        mainMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(false);
    }

    // Function to check if the game is currently paused
    private bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }
}
