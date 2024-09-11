using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using ColorUtility = UnityEngine.ColorUtility;

public class SaveLoad : MonoBehaviour
{
    
    [SerializeField] private AvatarEditorMenu avatarEditorMenu;

    public static SaveLoad Instance { get; private set; }

    [SerializeField] private GameObject mainAvatar;
    [SerializeField] private Camera screenshotCamera;
    [SerializeField] private Canvas saveCanvas;
    [SerializeField] private TMP_InputField saveNameInputField;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button cancelButton;
    
    [SerializeField] public GameObject Head;
    [SerializeField] public GameObject Hands;
    [SerializeField] public GameObject Body;
    [SerializeField] public GameObject Feet;

    private void Awake()
    {
        Instance = this;

        saveCanvas.gameObject.SetActive(false);
        saveButton.onClick.AddListener(OnSaveButtonClicked);
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    [Serializable]
    public class SaveData
    {
        public string headColor;
        public string bodyColor;
        public string handColor;
        public string footColor;
        public List<string> activeGameObjects = new List<string>();
    }

    public class FileDataWithImage
    {
        [Serializable]
        public class Header
        {
            public int jsonByteSize;
        }

        public static void Save(string json, Texture2D screenshot, string fileName)
        {
            byte[] jsonByteArray = Encoding.Unicode.GetBytes(json);
            byte[] screenshotByteArray = screenshot.EncodeToPNG();

            Header header = new Header
            {
                jsonByteSize = jsonByteArray.Length
            };
            string headerJson = JsonUtility.ToJson(header);
            byte[] headerJsonByteArray = Encoding.Unicode.GetBytes(headerJson);

            ushort headerSize = (ushort)headerJsonByteArray.Length;
            byte[] headerSizeByteArray = BitConverter.GetBytes(headerSize);

            List<byte> byteList = new List<byte>();
            byteList.AddRange(headerSizeByteArray);
            byteList.AddRange(headerJsonByteArray);
            byteList.AddRange(jsonByteArray);
            byteList.AddRange(screenshotByteArray);

            string path = Application.dataPath + $"/SaveFileScreenshot/{fileName}.bytesave";
            File.WriteAllBytes(path, byteList.ToArray());
            Debug.Log("Saved to: " + path);
        }

        public static void Load(out SaveData saveData, out Texture2D screenshotTexture2D, string fileName)
        {
            string path = Application.dataPath + $"/SaveFileScreenshot/{fileName}.bytesave";
            if (!File.Exists(path))
            {
                Debug.LogError("Save file not found: " + path);
                saveData = null;
                screenshotTexture2D = null;
                return;
            }

            byte[] byteArray = File.ReadAllBytes(path);
            List<byte> byteList = new List<byte>(byteArray);

            ushort headerSize = BitConverter.ToUInt16(new byte[] { byteArray[0], byteArray[1] }, 0);
            List<byte> headerByteList = byteList.GetRange(2, headerSize);
            string headerJson = Encoding.Unicode.GetString(headerByteList.ToArray());
            Header header = JsonUtility.FromJson<Header>(headerJson);

            List<byte> jsonByteList = byteList.GetRange(2 + headerSize, header.jsonByteSize);
            string gameDataJson = Encoding.Unicode.GetString(jsonByteList.ToArray());
            saveData = JsonUtility.FromJson<SaveData>(gameDataJson);

            int startIndex = 2 + headerSize + header.jsonByteSize;
            int endIndex = byteArray.Length - startIndex;
            List<byte> screenshotByteList = byteList.GetRange(startIndex, endIndex);
            screenshotTexture2D = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            screenshotTexture2D.LoadImage(screenshotByteList.ToArray());

            Debug.Log("Loaded from: " + path);
        }
    }

    public string GetSaveDataJSON()
    {
        SaveData saveData = new SaveData();

        List<GameObject> gameObjects = avatarEditorMenu.GetAllGameObjects();

        foreach (GameObject obj in gameObjects)
        {
            if (obj.gameObject.activeSelf)
            {
                saveData.activeGameObjects.Add(obj.name);
            }
        }

        saveData.headColor = getColor(Head);
        saveData.bodyColor = getColor(Body);
        saveData.handColor = getColor(Hands);
        saveData.footColor = getColor(Feet);

        string json = JsonUtility.ToJson(saveData);
        return json;
    }

    private string getColor(GameObject targetObject)
    {
        var renderer = targetObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            return XColor.ToHexString(renderer.material.color);
        }

        return null;
    }

    public void Save()
    {
        Debug.Log("save calleddddd");
        saveCanvas.gameObject.SetActive(true); // Show the save UI
    }

    private void OnCancelButtonClicked()
    {
        saveCanvas.gameObject.SetActive(false);
    }

    private void OnSaveButtonClicked()
    {
        string saveName = saveNameInputField.text;
        if (string.IsNullOrEmpty(saveName))
        {
            Debug.LogError("Save name cannot be empty.");
            return;
        }

        saveCanvas.gameObject.SetActive(false); // Hide the save UI

        string json = GetSaveDataJSON();
        byte[] jsonByteArray = Encoding.Unicode.GetBytes(json);

        Debug.Log("Taking screenshot for save...");
        StartCoroutine(TakeScreenshot(1080, 1920, (Texture2D screenshotTexture) =>
        {
            Debug.Log("Screenshot taken.");

            byte[] screenshotByteArray = screenshotTexture.EncodeToPNG();
            List<byte> byteList = new List<byte>(jsonByteArray);
            byteList.AddRange(screenshotByteArray);
            FileDataWithImage.Save(json, screenshotTexture, saveName);
        }));
    }

    public void Load(string fileName)
    {
        FileDataWithImage.Load(out SaveData saveData, out Texture2D screenshotTexture2D, fileName);
        
        
        if (saveData == null || screenshotTexture2D == null)
        {
            Debug.LogError("Load failed: Save data or screenshot texture is null.");
            return;
        }

        List<GameObject> gameObjects = avatarEditorMenu.GetAllGameObjects();
        
        foreach (GameObject obj in gameObjects)
        {
            bool isActive = saveData.activeGameObjects.Contains(obj.name);
            obj.gameObject.SetActive(isActive);
            Debug.Log($"Setting {obj.name} active state to {isActive}");
        }
        
        changeColor(Head, saveData.headColor);
        changeColor(Body, saveData.bodyColor);
        changeColor(Hands, saveData.handColor);
        changeColor(Feet, saveData.footColor);
    }
    
    private void changeColor(GameObject targetObject, string hexColor)
    {
        if (hexColor == null)
        {
            var renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.white;
            } 
        }
        else
        {
            if (ColorUtility.TryParseHtmlString($"#{hexColor}", out Color newColor))
            {
                var renderer = targetObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = newColor;
                }
                else
                {
                    Debug.LogWarning("The target object does not have a Renderer component.");
                }
            }
            else
            {
                Debug.LogWarning("Invalid color code.");
            }
        }
        
    }

    private IEnumerator TakeScreenshot(int width, int height, Action<Texture2D> onScreenshotTaken)
    {
        // Temporarily enable the screenshot camera and disable other cameras
        Camera mainCamera = Camera.main;
        mainCamera.enabled = false;
        screenshotCamera.enabled = true;

        // Set the render target
        RenderTexture renderTexture = new RenderTexture(width, height, 16);
        screenshotCamera.targetTexture = renderTexture;
        yield return new WaitForEndOfFrame();

        // Render the camera's view to the render texture
        screenshotCamera.Render();

        // Capture the screenshot
        RenderTexture.active = renderTexture;
        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        renderResult.ReadPixels(rect, 0, 0);
        renderResult.Apply();

        // Save the RenderTexture to disk for debugging
        byte[] bytes = renderResult.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/renderTextureDebug.png", bytes);
        Debug.Log("RenderTexture saved to disk for debugging.");

        // Clean up
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        renderTexture.Release();

        // Switch back to the main camera
        screenshotCamera.enabled = false;
        mainCamera.enabled = true;

        onScreenshotTaken(renderResult);
        Debug.Log("Screenshot processing completed.");
    }
}
