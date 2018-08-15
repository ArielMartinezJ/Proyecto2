using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera Variables
    public float panSpeed = 20f; //how fast we can move the camera across the world
    public float panBorderThickness = 10f; //how close we need to be to the border to move the camera with the mouse
    public Vector2 panLimit; //how far can the player move the camera to the sides and to the top and bottom
    private Vector3 cameraPos;

    //Mouse Variables
    public float scrollSpeed = 20f;
    public float minY = 20f; //so the player does not scroll inside buildings
    public float maxY = 120f;
    private float scroll;

    void Start()
    {
        cameraPos = transform.position;
    }

    void Update ()
    {
        CameraMovement();
        CameraScroll();

        cameraPos.x = Mathf.Clamp(cameraPos.x, -panLimit.x, panLimit.x);
        cameraPos.y = Mathf.Clamp(cameraPos.y, minY, maxY);
        cameraPos.z = Mathf.Clamp(cameraPos.z, -panLimit.y, panLimit.y);

        transform.position = cameraPos;

    }

    void CameraMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            cameraPos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            cameraPos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            cameraPos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            cameraPos.x -= panSpeed * Time.deltaTime;
        }
    }

    void CameraScroll()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraPos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
    }
}
