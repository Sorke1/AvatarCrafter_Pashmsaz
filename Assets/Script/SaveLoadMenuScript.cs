using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoadMenuScript : MonoBehaviour
{
    [SerializeField] private UIDocument saveLoadUIDocument;
    [SerializeField] private SaveLoad saveLoadInstance;

    private VisualElement root;
    private ListView saveListView;
    private List<string> saveFileNames = new List<string>();

    private void Awake()
    {
        root = saveLoadUIDocument.rootVisualElement;

        saveListView = root.Q<ListView>("saveListView");
        saveListView.makeItem = MakeListViewItem;
        saveListView.bindItem = BindListViewItem;
        saveListView.itemsSource = saveFileNames;
        saveListView.onSelectionChange += OnSaveFileSelected;

        LoadSaveFiles();
    }

  private VisualElement MakeListViewItem()
{
    var container = new VisualElement();
    container.style.flexDirection = FlexDirection.Row;
    container.style.height = 100;

    var img = new Image();
    img.name = "screenshot";
    img.style.width = 90;
    img.style.height = 90;
    container.Add(img);

    var label = new Label();
    label.style.fontSize = 20;
    label.style.unityFontStyleAndWeight = FontStyle.Bold; // Make the font bold
    label.style.color = Color.white; // Set the font color to white
    label.name = "label";
    container.Add(label);

    return container;
}


    private void BindListViewItem(VisualElement element, int index)
    {
        var saveFile = saveFileNames[index];
        var img = element.Q<Image>("screenshot");
        var label = element.Q<Label>("label");

        label.text = saveFile;
        img.image = LoadScreenshot(saveFile);
    }

    private void LoadSaveFiles()
    {
        string path = Application.dataPath + "/SaveFileScreenshot/";
        if (Directory.Exists(path))
        {
            var files = Directory.GetFiles(path, "*.bytesave");
            foreach (var file in files)
            {
                saveFileNames.Add(Path.GetFileNameWithoutExtension(file));
            }
            saveListView.Rebuild();
        }
    }

    private void OnSaveFileSelected(IEnumerable<object> selectedItems)
    {
        foreach (var item in selectedItems)
        {
            var fileName = item as string;
            if (!string.IsNullOrEmpty(fileName))
            {
                saveLoadInstance.Load(fileName);
            }
        }
    }

    private Texture2D LoadScreenshot(string fileName)
    {
        string path = Application.dataPath + $"/SaveFileScreenshot/{fileName}.bytesave";
        if (File.Exists(path))
        {
            byte[] byteArray = File.ReadAllBytes(path);
            List<byte> byteList = new List<byte>(byteArray);

            ushort headerSize = BitConverter.ToUInt16(new byte[] { byteArray[0], byteArray[1] }, 0);
            List<byte> headerByteList = byteList.GetRange(2, headerSize);
            string headerJson = System.Text.Encoding.Unicode.GetString(headerByteList.ToArray());
            var header = JsonUtility.FromJson<SaveLoad.FileDataWithImage.Header>(headerJson);

            int startIndex = 2 + headerSize + header.jsonByteSize;
            int endIndex = byteArray.Length - startIndex;
            List<byte> screenshotByteList = byteList.GetRange(startIndex, endIndex);
            Texture2D screenshotTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            screenshotTexture.LoadImage(screenshotByteList.ToArray());

            return screenshotTexture;
        }
        return null;
    }
}
