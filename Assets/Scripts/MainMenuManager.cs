using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
            if (mainMenuPanel.activeSelf)
            {
                ResumeGame();
                print("resume game: " + Time.timeScale);
            }
            else
            {
                PauseGame();
                print("pause game: " + Time.timeScale);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        mainMenuPanel.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        mainMenuPanel.SetActive(false);
    }

 
}
