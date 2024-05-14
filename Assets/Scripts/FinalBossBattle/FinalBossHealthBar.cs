using UnityEngine;
using UnityEngine.UI;

public class FinalBossHealthBar : MonoBehaviour
{
    public Image[] hearts; // Array to hold heart images for the health bar
    private int maxLives; // Maximum number of lives the enemy can have

    // Start is called before the first frame update
    void Start()
    {
        // Find the enemy object and get its maxLives
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            if (enemyBehaviour != null)
            {
                maxLives = enemyBehaviour.maxLives;
            }
        }

        // Initialize the health bar with the correct number of hearts
        InitializeHealthBar();
    }

    // Method to initialize the health bar with the correct number of hearts
    void InitializeHealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Activate or deactivate heart images based on the maximum number of lives
            hearts[i].gameObject.SetActive(i < maxLives);
        }
    }

    // Method to update the health bar
    public void UpdateHealthBar(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Activate or deactivate heart images based on the current number of lives
            hearts[i].gameObject.SetActive(i < currentLives);
        }
    }
}
