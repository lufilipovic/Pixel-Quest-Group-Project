using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Transform transitionPoint; // Specific point in the next scene where the player will appear
    public bool interacted = false;

    public GameObject errorPanel;

    private void Start()
    {
        errorPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interacted) // Check if the player has interacted with the NPCVillager
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                if (transitionPoint != null)
                {
                    other.transform.position = transitionPoint.position;
                }
            }
            else
            {
                errorPanel.SetActive(true);
            }
        }
    }

    public void closePanel()
    {
        errorPanel.SetActive(false);
    }
}

