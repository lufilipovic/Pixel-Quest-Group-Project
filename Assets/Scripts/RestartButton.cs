using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void RestartGame()
    {
        // Get the current active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

