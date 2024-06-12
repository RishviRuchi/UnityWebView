using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PageOpener : MonoBehaviour
{
    public Image imageviewForIFrame;
    [DllImport("__Internal")]
    private static extern void OpenWebPageInImage(string url, int x, int y, int width, int height);
    [DllImport("__Internal")]
    private static extern void HideWebPageInImage();
    [DllImport("__Internal")]
    private static extern void ShowWebPageInImage();

    [DllImport("__Internal")]
    private static extern void RemoveWebPageInImage();
    [DllImport("__Internal")]
    private static extern void UpdateIframePositionAndSize();
    [DllImport("__Internal")]
    private static extern void startIframeCapture(string iframeId,int interval);

    [DllImport("__Internal")]
    private static extern void captureIframeAsImage(string iframeId);
    public void OpenWebPage(string url, int x, int y, int width, int height)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            OpenWebPageInImage(url, x, y, width, height);
#else
        Debug.Log("Can only open web page in WebGL build.");
#endif
    }
    public void HideWebPage()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            HideWebPageInImage();
#else
        Debug.Log("Can only hide web page in WebGL build.");
#endif
    }

    public void ShowWebPage()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            ShowWebPageInImage();
#else
        Debug.Log("Can only show web page in WebGL build.");
#endif
    }

    public void RemoveWebPage()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            RemoveWebPageInImage();
#else
        Debug.Log("Can only remove web page in WebGL build.");
#endif
    }
    public void UpdateSize()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            UpdateIframePositionAndSize();
#else
        Debug.Log("Can only update iframe position and size in WebGL build.");
#endif
    }

    public void ReceiveImageData(string dataURL)
    {
        StartCoroutine(LoadImage(dataURL));
    }

     IEnumerator LoadImage(string dataURL)
    {
        // Remove the data URL header
        string base64Data = dataURL.Substring(dataURL.IndexOf(',') + 1);

        byte[] imageBytes = System.Convert.FromBase64String(base64Data);

        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(imageBytes);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
      /*  imageviewForIFrame.color = Color.green;
        imageviewForIFrame.sprite = sprite;*/
       // imageviewForIFrame.texture = tex;
        print("Success");

    // Apply the texture to a renderer
    //  targetRenderer.material.mainTexture = texture;

        yield return null;
    }

    public void StartIframeCapture(string iframeId, int interval)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            startIframeCapture(iframeId, interval);
#else
        Debug.Log("startIframeCapture Error.");
#endif
    }
    public void CaptureIFrameAs_Image(string iframeId)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            captureIframeAsImage(iframeId);
#else
        Debug.Log("startIframeCapture Error.");
#endif
    }
}