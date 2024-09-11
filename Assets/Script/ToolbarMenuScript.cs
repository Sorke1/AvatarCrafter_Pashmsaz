using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject toolbarUI; // Replace UIDocument with a GameObject holding UI elements
    [SerializeField] private SaveLoad saveLoadInstance;
    [SerializeField] private CameraOrbit cameraOrbit;
    [SerializeField] private AvatarEditorMenu avatarEditorMenu;

    private Button saveButton;
    private InputField saveNameInputField; // Using UnityEngine.UI.InputField instead of TextField
    
    public GameObject avatar;

    private void Awake()
    {
        // Assume toolbarUI contains references to the UI components
        saveNameInputField = toolbarUI.transform.Find("SaveNameInputField").GetComponent<InputField>();

        // Assuming there's a button in the toolbar for saving
        saveButton = toolbarUI.transform.Find("BtnSave").GetComponent<Button>();
        saveButton.onClick.AddListener(OnSaveButtonClicked);
        
        var resetCameraButton = toolbarUI.transform.Find("BtnResetCamera").GetComponent<Button>();
        resetCameraButton.onClick.AddListener(OnResetCameraButtonClicked);
        
        var resetAvatarButton = toolbarUI.transform.Find("BtnResetAvatar").GetComponent<Button>();
        resetAvatarButton.onClick.AddListener(OnResetAvatarButtonClicked);
        
        var exportButton = toolbarUI.transform.Find("BtnExport").GetComponent<Button>();
        exportButton.onClick.AddListener(OnExportButtonClicked);
    }

    private void OnExportButtonClicked()
    {
        // Export functionality is removed because it requires UnityEditor functionality
        Debug.Log("Export button clicked, but exporting is disabled in runtime.");
    }

    private void OnResetCameraButtonClicked()
    {
        if (cameraOrbit != null)
        {
            cameraOrbit.ResetCameraOrbit();
        }
    }
    
    private void OnResetAvatarButtonClicked()
    {
        if (avatarEditorMenu != null)
        {
            avatarEditorMenu.ResetAvatar();
        }
    }

    private void OnSaveButtonClicked()
    {
        saveLoadInstance.Save();
        Debug.Log("Save button clicked.");
    }
}
