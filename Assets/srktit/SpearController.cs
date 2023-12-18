using UnityEngine;

public class SpearController : MonoBehaviour
{
    public float speed = -300f;

    void Update()
    {
        // Move the spear forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // Destroy the spear when it becomes invisible (off-screen)
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the spear hits the player
        if (other.CompareTag("Player"))
        {
            // You can add any player hit logic here
            Debug.Log("Spear hit the player!");
            Destroy(gameObject);
        }
    }
}