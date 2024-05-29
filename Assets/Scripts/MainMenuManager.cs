using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Reference to the main menu panel GameObject

    // Cached screen dimensions to avoid recalculating them every update
    private float screenWidth;
    private float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(false); // Hide the main menu panel at start
        Time.timeScale = 1f; // Ensure the game is running normally at start

        // Calculate and cache the screen dimensions
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle between pausing and resuming the game
            if (IsGamePaused())
            {
                ResumeGame();
                Debug.Log("Resuming game: " + Time.timeScale);
            }
            else
            {
                PauseGame();
                Debug.Log("Pausing game: " + Time.timeScale);
            }
        }
    }

    // Function to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
        mainMenuPanel.SetActive(true); // Show the main menu panel
    }

    // Function to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Set time scale back to 1 to resume the game
        mainMenuPanel.SetActive(false); // Hide the main menu panel
    }

    // Function to check if the game is currently paused
    private bool IsGamePaused()
    {
        return Time.timeScale == 0f; // Return true if time scale is 0 (game is paused)
    }
}
