using UnityEngine;

public class SpearSpawner : MonoBehaviour
{
    public GameObject spearPrefab;
    public float spawnInterval = 2f; // Time between spear spawns
    public int maxSpears = 5; // Maximum number of spears to spawn
    private float timer;
    private bool isSpawningEnabled = false; // Flag to control spawning

    // Flag to check if the game is over
    private bool isGameOver = false;

    void Update()
    {
        // Check if spawning is enabled and the game is not over
        if (isSpawningEnabled && !isGameOver)
        {
            // Check if it's time to spawn a new spear
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                // Reset the timer
                timer = 0f;

                // Spawn a new spear
                SpawnSpear();
            }
        }
    }

    void SpawnSpear()
    {
        // Instantiate the spear prefab
        GameObject spear = Instantiate(spearPrefab, transform.position, Quaternion.identity);

        // You can set additional properties or behaviors here if needed
        // For example, you might want to set the speed of the spear
        spear.GetComponent<SpearController>().speed = -300f;

        // Destroy the spear after a certain time (adjust as needed)
        Destroy(spear, 10f); // Assuming the spear takes 10 seconds to go off-screen naturally
    }

    // Method to enable or disable spawning
    public void ToggleSpawningState()
    {
        isSpawningEnabled = !isSpawningEnabled;

        // You can add additional logic or feedback here if needed
        if (isSpawningEnabled)
        {
            Debug.Log("Spawning enabled!");
        }
        else
        {
            Debug.Log("Spawning disabled!");
        }
    }

    // Method to set the game over state
    public void SetGameOverState(bool gameOver)
    {
        isGameOver = gameOver;

        // You can add additional logic or feedback here if needed
        if (isGameOver)
        {
            Debug.Log("Game Over!");
        }
    }
}