using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

public class PageTool : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void GoFullscreen();
  public void FullScreenByJava()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
   
   
        GoFullscreen();
    

#endif
    }
}