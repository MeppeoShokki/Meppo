using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button targetButton;
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip clickSound; // Assign the audio clip for the button click sound in the Unity Editor

    private void Start()
    {
        // Ensure that the targetButton is assigned
        if (targetButton == null)
        {
            Debug.LogError("Target Button is not assigned to the button controller!");
        }

        // Make sure to assign an AudioSource component to this variable in the Unity Editor
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Attach the OnButtonClick method to the button's onClick event
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        // Check if the target button is not null
        if (targetButton != null)
        {
            // Disable the target button
            targetButton.gameObject.SetActive(false);

            // Play the assigned click sound
            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }
        }
    }
}