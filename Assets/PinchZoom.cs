using UnityEngine;
using UnityEngine.UI;

public class PinchZoom : MonoBehaviour
{

    
    public RectTransform rectTransform;
    public ScrollRect2 scrollRect;
    public float zoomSpeed = 0.05f;


    float ZoomState = 1;


    void Update()
    {

      
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            //Disable the scrollRect
            scrollRect.enabled = false;
            //Update the rect pivot and set it to the first touch point
            rectTransform.pivot = new Vector2(Input.GetTouch(0).position.x / Screen.width, Input.GetTouch(0).position.y / Screen.height);


            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ... change the canvas size based on the change in distance between the touches.
            ZoomState -= (deltaMagnitudeDiff *Time.unscaledDeltaTime)*zoomSpeed;

            // Make sure the canvas size never drops below 0.1
            ZoomState = Mathf.Clamp(ZoomState, 1f,2f);
            rectTransform.localScale = Vector3.one * ZoomState;
        }
        else
        {
            if (Input.touchCount < 1)
                scrollRect.enabled = true;
         
        }
    }
}