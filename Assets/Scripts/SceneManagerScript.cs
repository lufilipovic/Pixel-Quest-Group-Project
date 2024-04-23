using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public GameObject howToPlayPanel;

    private void Start()
    {
        howToPlayPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
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

    public void PlayGame()
    {
        //Load next scene in the build level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        print("Game Exited");

        //Quit the application
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        howToPlayPanel.SetActive(true);
        print("Pausing game: " + Time.timeScale);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        howToPlayPanel.SetActive(false);
        print("Resuming game: " + Time.timeScale);
    }

    // Function to check if the game is currently paused
    private bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }


}
