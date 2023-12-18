using UnityEngine;
using UnityEngine.UI;

public class UIButtonAudioPlayer : MonoBehaviour
{
    public Button yourButton;
    public AudioSource audioSource;

    void Start()
    {
        // Attach a listener to the button click event
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Play the audio clip when the button is clicked
        audioSource.Play();
    }
}
