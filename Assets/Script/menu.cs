using UnityEngine;
using UnityEngine.UIElements;  // For UI Toolkit

public class menu : MonoBehaviour
{
    public UIDocument uiDocument;
    private VisualElement btnSound;  // Use VisualElement for the mute/unmute toggle

    [SerializeField] private AudioSource musicSource;
    public AudioClip backgroundMusic;

    private bool isMuted = false;  // Music is playing by default

    private void Start()
    {
        // Get the root VisualElement from the UIDocument
        var root = uiDocument.rootVisualElement;

        // Query the visual element named "btnSound" (ensure the name matches in the UI Builder)
        btnSound = root.Q<VisualElement>("btnSound");

        // Check if the element was found
        if (btnSound != null)
        {
            // Register a click event for the VisualElement
            btnSound.RegisterCallback<ClickEvent>(ev => ToggleSound());
        }
        else
        {
            Debug.LogError("VisualElement 'btnSound' not found in the UI!");
        }

        // Initialize and start playing the background music
        InitializeMusic();
    }

    // Initialize the background music and play it by default
    private void InitializeMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;  // Loop the background music
            musicSource.Play();       // Start playing music by default
            isMuted = false;          // Mark as not muted
        }
        else
        {
            Debug.LogError("AudioSource or backgroundMusic is not assigned!");
        }
    }

    // Toggle the sound on or off when the VisualElement is clicked
    private void ToggleSound()
    {
        if (isMuted)
        {
            musicSource.Play();   // Resume playing the music
            isMuted = false;      // Mark as not muted
        }
        else
        {
            musicSource.Pause();  // Pause the music
            isMuted = true;       // Mark as muted
        }
    }
}
