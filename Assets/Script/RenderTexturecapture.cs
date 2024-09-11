using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RenderTexturecapture : MonoBehaviour
{

public RenderTexture ExportCamera;

    public void ExportPhoto()
    {
        StartCoroutine(CapturePhoto());
    }

    private IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();

        byte[] bytes = toTexture2D(ExportCamera).EncodeToPNG();
        var dirPath = Application.persistentDataPath + "/ExportPhoto";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + "/Photo_" + Random.Range(0, 100000) + ".png", bytes);
        Debug.Log(dirPath);
    }

    private Texture2D toTexture2D(RenderTexture rText)
    {
        RenderTexture.active = rText;
        Texture2D tex = new Texture2D(rText.width, rText.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, rText.width, rText.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null; // Reset the active RenderTexture
        return tex;
    }


    // public IEnumerator TakePhoto()
    // {


    //     var dirPath = Application.persistentDataPath + "/ExportPhoto";

    //     // NOTE - you almost certainly have to do this here:

    //     yield return new WaitForEndOfFrame(); 

    //     // it's a rare case where the Unity doco is pretty clear,
    //     // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
    //     // be sure to scroll down to the SECOND long example on that doco page 

    //     Texture2D photo = new Texture2D(ExportCamera.width, ExportCamera.height);
    //     // photo.SetPixels(ExportCamera);
    //     photo.Apply();

    //     //Encode to a PNG
    //     byte[] bytes = photo.EncodeToPNG();
    //     //Write out the PNG. Of course you have to substitute your_path for something sensible
    //     File.WriteAllBytes(dirPath + "/Photo_" + Random.Range(0, 100000) + ".png", bytes);
    // }

    // Texture2D toTexture2D(RenderTexture rt)
    // {

    //     // Remember currently active render texture
    //     RenderTexture currentActiveRT = RenderTexture.active;

    //     // Set the supplied RenderTexture as the active one
    //     RenderTexture.active = rt;

    //     // Create a new Texture2D and read the RenderTexture image into it
    //     Texture2D tex = new Texture2D(rt.width, rt.height);
    //     tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
    //     tex.Apply();

    //     // Restore previously active render texture
    //     RenderTexture.active = currentActiveRT;
    //     return tex;
    // }

}
