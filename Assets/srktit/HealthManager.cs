using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public SpearSpawner spearSpawner;
    public int maxHealth = 4; // Maximum health
    private int currentHealth; // Current health
    private bool isGameOver = false;
    private MoveObjectOnButtonClick playerMovement;

    public HealthBar healthBar;
    public Button restartButton; // Reference to the restart button

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        playerMovement = GetComponent<MoveObjectOnButtonClick>();

        // Disable the restart button at the start
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is hit by a spear
        if (other.CompareTag("Spear"))
        {
            // Decrease health
            TakeDamage(1);

            // Destroy the spear
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // Ensure health doesn't go below 0
        currentHealth = Mathf.Max(0, currentHealth);

        // Update the health bar
        healthBar.SetHealth(currentHealth);

        // Check if the player is out of health
        if (currentHealth <= 0)
        {
            // Perform game over logic (e.g., show game over screen, reload level, etc.)
            Debug.Log("Game Over");

            // Enable the restart button
            if (restartButton != null)
            {
                restartButton.gameObject.SetActive(true);
            }

            // End the game
            EndGame();
        }
    }

    void EndGame()
    {
        if (playerMovement != null)
        {
            playerMovement.DisableMovement();
        }

        // Set the game over state
        isGameOver = true;

        // Stop spear spawning
        if (spearSpawner != null)
        {
            spearSpawner.ToggleSpawningState();
        }
    

    // Set the game over state
    isGameOver = true;
    }

    // Public method to be called when the restart button is clicked
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }
}