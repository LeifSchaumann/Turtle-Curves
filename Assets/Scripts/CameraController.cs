using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
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
    Vector3 desiredPos;
    float desiredZoom;

    void Awake()
    {
        myCamera = GetComponent<Camera>();

        desiredPos = transform.position;
        desiredZoom = myCamera.orthographicSize;
        
    }

    void Update()
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
}
