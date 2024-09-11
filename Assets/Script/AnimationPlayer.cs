using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationPlayer : MonoBehaviour
{
    public UIDocument uiDocument;
    
    private VisualElement btnBoxing;
    private VisualElement btnDancing;
    private VisualElement btnDI;
    private VisualElement btnSitting;
    private VisualElement btnBreathing;
    
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Get the root visual element from the UI document
        VisualElement root = uiDocument.rootVisualElement;
        
        btnBoxing = root.Q<VisualElement>("btnBoxing");
        btnDancing = root.Q<VisualElement>("btnDancing");
        btnDI = root.Q<VisualElement>("btnDI");
        btnSitting = root.Q<VisualElement>("btnSitting");

        // Find the button by its name in the UI

        btnBoxing.RegisterCallback<ClickEvent>(ev => PlayAnimation("Boxing"));
        btnDancing.RegisterCallback<ClickEvent>(ev => PlayAnimation("mixamo_com"));
        btnDI.RegisterCallback<ClickEvent>(ev => PlayAnimation("test"));
        btnSitting.RegisterCallback<ClickEvent>(ev => PlayAnimation("Situp"));
    }

    // Method to play the animation
    private void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
        else
        {
            Debug.LogError("Animator component not found.");
        }
    }
}
