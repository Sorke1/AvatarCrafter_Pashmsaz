using UnityEngine;
using UnityEngine.UIElements;

public class Animation : MonoBehaviour
{
    public UIDocument _document;

    // Constants for slider limits
    private const int MinValue = -5;
    private const int MaxValue = 5;

    // Visual Elements in the UI
    private VisualElement headElement;
    private VisualElement rightArmElement;
    private VisualElement leftArmElement;
    private VisualElement rightUpperLegElement;
    private VisualElement leftUpperLegElement;

    // Sliders in the UI
    private SliderInt xSlider;
    private SliderInt ySlider;
    private SliderInt zSlider;

    // Selected Transform
    private Transform selectedTransform;

    void Start()
    {
        // Access the root visual element of the UI document
        VisualElement root = _document.rootVisualElement;

        // Find Visual Elements by their names
        headElement = root.Q<VisualElement>("headElement");
        rightArmElement = root.Q<VisualElement>("rightArmElement");
        leftArmElement = root.Q<VisualElement>("leftArmElement");
        rightUpperLegElement = root.Q<VisualElement>("rightUpperLegElement");
        leftUpperLegElement = root.Q<VisualElement>("leftUpperLegElement");

        // Find UI sliders by their names and set their limits using constants
        xSlider = root.Q<SliderInt>("xSlider");
        ySlider = root.Q<SliderInt>("ySlider");
        zSlider = root.Q<SliderInt>("zSlider");

        xSlider.lowValue = MinValue;
        xSlider.highValue = MaxValue;
        ySlider.lowValue = MinValue;
        ySlider.highValue = MaxValue;
        zSlider.lowValue = MinValue;
        zSlider.highValue = MaxValue;

        // Assign click events to select the appropriate target
        headElement.RegisterCallback<ClickEvent>(evt => SelectTransform("HeadTarget"));
        leftArmElement.RegisterCallback<ClickEvent>(evt => SelectTransform("RightArmAimTarget"));
        rightArmElement.RegisterCallback<ClickEvent>(evt => SelectTransform("LeftArmAimTarget"));
        leftUpperLegElement.RegisterCallback<ClickEvent>(evt => SelectTransform("RightUpLegAimTarget"));
        rightUpperLegElement.RegisterCallback<ClickEvent>(evt => SelectTransform("LeftUpLegAimTarget"));

        // Assign slider value change events to update the selected transform's position
        xSlider.RegisterValueChangedCallback(evt => UpdatePosition(Vector3.right, evt.newValue));
        ySlider.RegisterValueChangedCallback(evt => UpdatePosition(Vector3.up, evt.newValue));
        zSlider.RegisterValueChangedCallback(evt => UpdatePosition(Vector3.forward, evt.newValue));
    }

    private void SelectTransform(string targetName)
    {
        // Find the target transform by name
        selectedTransform = GameObject.Find(targetName)?.transform;

        if (selectedTransform != null)
        {
            // Initialize sliders with the current position values of the selected transform
            Vector3 position = selectedTransform.localPosition;
            xSlider.value = Mathf.Clamp((int)position.x, MinValue, MaxValue);
            ySlider.value = Mathf.Clamp((int)position.y, MinValue, MaxValue);
            zSlider.value = Mathf.Clamp((int)position.z, MinValue, MaxValue);
        }
        else
        {
            Debug.LogWarning("Transform not found: " + targetName);
        }
    }

    private void UpdatePosition(Vector3 axis, float value)
    {
        if (selectedTransform != null)
        {
            Vector3 position = selectedTransform.localPosition;
            value = Mathf.Clamp(value, MinValue, MaxValue);

            if (axis == Vector3.right)
            {
                position.x = value;
            }
            else if (axis == Vector3.up)
            {
                position.y = value;
            }
            else if (axis == Vector3.forward)
            {
                position.z = value;
            }

            selectedTransform.localPosition = position;
        }
    }
}
