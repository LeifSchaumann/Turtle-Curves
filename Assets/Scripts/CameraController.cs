using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public TurtleCurveDrawer focusTCD;

    public float minAutoZoom;
    
    [Tooltip("Pan Speed")]
    public float panSpeed;

    [Tooltip("Pan Smooth Speed")]
    public float panSmoothSpeed;

    [Tooltip("Zoom Speed")]
    public float zoomSpeed;

    [Tooltip("Zoom Smooth Speed")]
    public float zoomSmoothSpeed;

    [Tooltip("Minimum Zoom")]
    public float minZoom;

    [Tooltip("Maximum Zoom")]
    public float maxZoom;

    Camera myCamera;
    public Vector3 desiredPos;
    public float desiredZoom;

    void Awake()
    {
        myCamera = GetComponent<Camera>();

        desiredPos = transform.position;
        desiredZoom = myCamera.orthographicSize;
        
    }

    void Update()
    {
        if (focusTCD == null)
        {
            // Calculate desired pos

            Vector3 posInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (posInput.magnitude > 0.5)
            {
                desiredPos += posInput.normalized * Time.deltaTime * panSpeed * (desiredZoom + 1);
            }

            // Calculate desired zoom

            float zoomChange = 1 - Input.GetAxisRaw("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime * 50;
            desiredZoom *= zoomChange;
            desiredZoom = Mathf.Clamp(desiredZoom, minZoom, maxZoom);

            // Center zoom on mouse

            if (desiredZoom > minZoom && desiredZoom < maxZoom)
            {
                desiredPos += (1 - zoomChange) * (myCamera.ScreenToWorldPoint(Input.mousePosition) - desiredPos);
            }

            // Move towards desired pos and zoom

            transform.position += (desiredPos - transform.position) * panSmoothSpeed;
            myCamera.orthographicSize += (desiredZoom - myCamera.orthographicSize) * zoomSmoothSpeed;
        }
        else
        {
            Rect TCbounds = focusTCD.turtleCurve.bounds;
            desiredPos = new Vector3(TCbounds.center.x, TCbounds.center.y, -10f);
            desiredZoom = Mathf.Max(TCbounds.height * 0.8f, minAutoZoom);

            // Move towards desired pos and zoom

            transform.position += (desiredPos - transform.position) * panSmoothSpeed / 5f;
            myCamera.orthographicSize += (desiredZoom - myCamera.orthographicSize) * zoomSmoothSpeed / 5f;
        }
        
        

        

        

    }
}
