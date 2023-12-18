using UnityEngine;

public class MoveObjectOnButtonClick : MonoBehaviour
{
    private bool isMoveEnabled = false;
    private bool isJumpEnabled = false;
    private bool isFacingRight = true; // Flag to track the player's facing direction
    private float moveSpeed = 200f;
    private float jumpForce = 200f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public AudioSource audioSource;
    public Sprite idleSprite;
    public Sprite runSprite1;
    public Sprite runSprite2;

    private float spriteChangeInterval = 0.3f; // Time interval for changing sprites
    private float timeSinceLastSpriteChange = 0f;
    private bool isRunSprite1 = true; // Flag to toggle between run sprites

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Enable gravity
        rb.gravityScale = 20f;

        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial sprite to the idle sprite
        if (spriteRenderer != null && idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    void Update()
    {
        // Check if movement is enabled
        if (isMoveEnabled)
        {
            // Move the GameObject based on user input or any other logic
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, 0f);
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y); // Adjust the speed as needed

            // Toggle between run sprites at the specified interval
            timeSinceLastSpriteChange += Time.deltaTime;
            if (timeSinceLastSpriteChange >= spriteChangeInterval)
            {
                timeSinceLastSpriteChange = 0f;
                ToggleRunSprite();
            }

            // Flip the sprite if moving to the left
            if (horizontalInput < 0 && isFacingRight)
            {
                FlipSprite();
            }
            // Flip the sprite back if moving to the right
            else if (horizontalInput > 0 && !isFacingRight)
            {
                FlipSprite();
            }
        }
        else
        {
            // Change the sprite to the idle sprite when not moving
            if (spriteRenderer != null && idleSprite != null)
            {
                spriteRenderer.sprite = idleSprite;
            }
        }

        // Check if jump is enabled
        if (isJumpEnabled && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply a vertical force for jumping
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Audio
            PlayJumpSound();
        }
    }

    void PlayJumpSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void ToggleRunSprite()
    {
        // Toggle between run sprites
        if (spriteRenderer != null && (runSprite1 != null || runSprite2 != null))
        {
            spriteRenderer.sprite = isRunSprite1 ? runSprite1 : runSprite2;
            isRunSprite1 = !isRunSprite1;
        }
    }

    void FlipSprite()
    {
        // Flip the sprite horizontally
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // Method to disable movement
    public void DisableMovement()
    {
        isMoveEnabled = false;
        isJumpEnabled = false;
    }

    // Method to enable movement
    public void EnableMovement()
    {
        isMoveEnabled = true;
        isJumpEnabled = true;
    }

    public void ToggleMoveState()
    {
        // Toggle the movement state when the button is clicked
        isMoveEnabled = !isMoveEnabled;

        // You can add additional logic or feedback here if needed
        if (isMoveEnabled)
        {
            Debug.Log("Movement enabled!");
        }
        else
        {
            Debug.Log("Movement disabled!");
        }
    }

    public void ToggleJumpState()
    {
        // Toggle the jump state when the button is clicked
        isJumpEnabled = !isJumpEnabled;

        // You can add additional logic or feedback here if needed
        if (isJumpEnabled)
        {
            Debug.Log("Jumping enabled!");
        }
        else
        {
            Debug.Log("Jumping disabled!");
        }
    }
}