using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Help : MonoBehaviour
{
    public UIDocument _document;

    private VisualElement btnHelp;  // Reference to the Help button
    private VisualElement _nextbutton;  // Reference to the Next button
    private VisualElement _previousbutton;  // Reference to the Previous button
    private VisualElement helpmenuactive;  // Reference to the Help menu
    public List<VisualElement> helpTextElements;  // List of text elements in the Help menu
    private int currentIndex = 0;  // Index to track the currently visible text element

    private void Awake()
    {
        var root = _document.rootVisualElement;

        // Get references to buttons and the help menu
        _nextbutton = root.Q<VisualElement>("Nextbtn");
        _previousbutton = root.Q<VisualElement>("Previousbtn");
        btnHelp = root.Q<VisualElement>("btnHelp");
        helpmenuactive = root.Q<VisualElement>("helpmenuactive");

        // Populate the help text elements list with "welcome" as the first element
        helpTextElements = new List<VisualElement>
        {
            root.Q<VisualElement>("welcome"),      // New element "welcome"
            root.Q<VisualElement>("resetAvatar"),
            root.Q<VisualElement>("resetcamera"),
            root.Q<VisualElement>("SaveExport"),
            root.Q<VisualElement>("accesories"),
            root.Q<VisualElement>("Animation"),
            root.Q<VisualElement>("Colour")
        };

        // Hide all text elements initially
        HideAllTextElements();

        // Register the click event for the btnHelp to toggle the menu
        if (btnHelp != null)
        {
            btnHelp.RegisterCallback<ClickEvent>(ev => ToggleHelpMenuVisibility());
        }

        // Register the Next and Previous button click events
        if (_nextbutton != null)
        {
            _nextbutton.RegisterCallback<ClickEvent>(NextEvent);
        }

        if (_previousbutton != null)
        {
            _previousbutton.RegisterCallback<ClickEvent>(PreviousEvent);
        }

        // Initially hide the help menu
        if (helpmenuactive != null)
        {
            helpmenuactive.style.display = DisplayStyle.None;
            Debug.Log("helpmenuactive visibility set to None.");
        }
    }

    // Method to handle the "Next" button click
    private void NextEvent(ClickEvent evt)
    {
        if (currentIndex < helpTextElements.Count - 1) // Ensure we don't go out of bounds
        {
            HideAllTextElements();  // Hide all text elements
            currentIndex++;         // Move to the next element
            ShowTextElement(currentIndex);  // Show the text at the new current index
        }
    }

    // Method to handle the "Previous" button click
    private void PreviousEvent(ClickEvent evt)
    {
        if (currentIndex > 0)  // Ensure we don't go below 0
        {
            HideAllTextElements();  // Hide all text elements
            currentIndex--;         // Move to the previous element
            ShowTextElement(currentIndex);  // Show the text at the new current index
        }
    }

    // Method to hide all text elements
    private void HideAllTextElements()
    {
        foreach (var element in helpTextElements)
        {
            element.style.display = DisplayStyle.None;  // Hide each element
        }
    }

    // Method to show a specific text element based on the index
    private void ShowTextElement(int index)
    {
        if (index >= 0 && index < helpTextElements.Count)  // Ensure index is valid
        {
            helpTextElements[index].style.display = DisplayStyle.Flex;  // Show the element
        }
    }

    // Method to toggle the visibility of the help menu
    private void ToggleHelpMenuVisibility()
    {
        if (helpmenuactive != null)
        {
            // Toggle the visibility of the helpmenuactive element
            if (helpmenuactive.style.display == DisplayStyle.None)
            {
                // Make it visible
                helpmenuactive.style.display = DisplayStyle.Flex;
                ShowTextElement(currentIndex);  // Show the current text element when help menu is opened
            }
            else
            {
                // Hide it again
                helpmenuactive.style.display = DisplayStyle.None;
                HideAllTextElements();  // Hide all text elements when the help menu is hidden
            }
        }
    }
}
