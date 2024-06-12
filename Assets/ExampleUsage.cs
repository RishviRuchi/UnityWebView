using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ExampleUsage : MonoBehaviour
{
    public PageOpener pageOpener;
    public RectTransform imageRectTransform;
    public GameObject canvasElement;
    bool isShown = false;
    public GameObject btnDisplay;
    public GameObject btnHide;
     public EventSystem eventSystem;
    public Image dummyImage;
    public bool isRed = false;
    public GameObject fsButton;
    public string _url= "https://lottobets.co/";//https://lottobets.co/
    void Start()
    {
        /*if (btnDisplay == null)
        {
            Debug.LogError("display reference not set in the inspector.");
            return;
        }

        // Add a listener to the button to simulate a click
        btnDisplay.onClick.AddListener(ShowWebPage);

        if (btnHide == null)
        {
            Debug.LogError("btnHide reference not set in the inspector.");
            return;
        }
*/
        // Add a listener to the button to simulate a click
        // btnHide.onClick.AddListener(HideWebPage);
        // Assuming pageOpener is set via the Inspector or another method
        // pageOpener.OpenAnotherPage("anotherPage.html");
        Invoke("ChangeImageColour",1.5f);
       
        // OnClick();
        Invoke("OnClick", 3f);
        //SimulateButtonPress(btnDisplay);
        SimulateButtonPress(fsButton);
       

    }
    public void TestMethod()
    {
         SimulateButtonPress(fsButton);
    }
   
    public void ChangeImageColour()
    {
        isRed = !isRed;
        if (!isRed)
            dummyImage.color = Color.red;
        else
             if (isRed)
            dummyImage.color = Color.green;
        Invoke("ChangeImageColour", 1.5f);
    }
    public void OnClick()
    {
        // SceneManager.LoadScene(1);
        // pageOpener.OpenAnotherPage("https://lottobets.co/");
        //  pageOpener.OpenAnotherPage("Build/TestHTML.html");
        Vector3[] corners = new Vector3[4];
        imageRectTransform.GetWorldCorners(corners);
        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];

        float x = bottomLeft.x;
        float y = Screen.height - topRight.y; // Invert y-axis for screen coordinates
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;
        
        pageOpener.OpenWebPage(_url, (int)x, 0, (int)width, (int)height);
        
       pageOpener.UpdateSize();
        SimulateButtonPress(btnDisplay);
      //  Invoke("AlternativelyShowHide", 2f);
      //pageOpener.CaptureIFrameAs_Image("iframe");
      //pageOpener.StartIframeCapture("iframe", 20);
      //pageOpener.OpenWebPage("https://lottobets.co/", 100, 100, 800, 600);
    }
    public void AlternativelyShowHide()
    {
        isShown = !isShown;
        if(!isShown)
        {
           // ShowWebPage();
            SimulateButtonPress(btnDisplay);
           // btnDisplay.onClick.Invoke();
        }
        if (isShown)
        {
           // HideWebPage();
            SimulateButtonPress(btnHide);
            //btnHide.onClick.Invoke();
        }
          
        Invoke("AlternativelyShowHide", 2f);
    }
    public void HideWebPage()
    {
        pageOpener.HideWebPage();
       // pageOpener.UpdateSize();
    }
   
    public void ShowWebPage()
    {
        pageOpener.ShowWebPage();
        pageOpener.UpdateSize();

    }

    public void RemoveWebPage()
    {
        pageOpener.RemoveWebPage();
    }
    public void FSButton()
    {
        Screen.fullScreen = true;
    }
    public void SimulateButtonPress(GameObject button)
    {
        print("St 1");
        // Check if EventSystem is available
        if (eventSystem != null)
        {
            print("St 2");

            // Create a new pointer event
            PointerEventData pointerEventData = new PointerEventData(eventSystem);

            // Set the pointer event position to the center of the button
            pointerEventData.position = button.transform.position;

            // Create a list to store the result of the raycast
            List<RaycastResult> raycastResults = new List<RaycastResult>();

            // Perform a raycast using the EventSystem
            eventSystem.RaycastAll(pointerEventData, raycastResults);
            eventSystem.SetSelectedGameObject(button);
            ExecuteEvents.Execute(button, pointerEventData, ExecuteEvents.submitHandler);

            // Simulate a pointer click event on the button if it was hit
            /* foreach (RaycastResult result in raycastResults)
             {
                 if (result.gameObject == button)
                 {
                     print("St 3");
                     eventSystem.SetSelectedGameObject(button);
                     eventSystem.SetSelectedGameObject(null);
                     ExecuteEvents.Execute(button, pointerEventData, ExecuteEvents.submitHandler);
                     break;
                 }
             }*/

            // Clear the list after use
            raycastResults.Clear();
        }
    }
}
/*
   setInterval(function() {
           if(iframe.style.display == 'none')
           {
            var canvas = document.getElementById('unity-canvas');
             canvas.style.display = 'none';
            iframe.style.display = 'block';
           }
           
           else
           if(iframe.style.display == 'block')
           {
            iframe.style.display = 'none';
            var canvas = document.getElementById('unity-canvas');
             canvas.style.display = 'block';
           }
          
           
        }, 6000);
 */