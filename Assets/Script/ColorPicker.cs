using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorPicker : MonoBehaviour
{
    private Slider redSlider;
    private Slider greenSlider;
    private Slider blueSlider;
    private VisualElement colorDisplay;

    public Action<Color> OnColorChanged;
    
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        redSlider = root.Q<Slider>("RedSlider");
        greenSlider = root.Q<Slider>("GreenSlider");
        blueSlider = root.Q<Slider>("BlueSlider");
        colorDisplay = root.Q<VisualElement>("ColorDisplay");

        // Register value change callbacks
        redSlider.RegisterValueChangedCallback(evt => UpdateColorDisplay());
        greenSlider.RegisterValueChangedCallback(evt => UpdateColorDisplay());
        blueSlider.RegisterValueChangedCallback(evt => UpdateColorDisplay());

        // Initialize with default color
        UpdateColorDisplay();
    }

    private void UpdateColorDisplay()
    {
        Color color = new Color(redSlider.value / 255f, greenSlider.value / 255f, blueSlider.value / 255f);
        colorDisplay.style.backgroundColor = new StyleColor(color);
        
        OnColorChanged?.Invoke(color);
        
    }

    public Color GetSelectedColor()
    {
        return new Color(redSlider.value / 255f, greenSlider.value / 255f, blueSlider.value / 255f);
    }
}