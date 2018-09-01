using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class UserInput : MonoBehaviour
{
    private Player player;

	void Start ()
    {
        player = transform.root.GetComponent<Player>();
	}
	
	void Update ()
    {
		if (player && player.isHuman)
        {
            MoveCamera();
            RotateCamera();
            MouseActivity();
        }
	}

    private void MouseActivity()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseClick();
        } else if (Input.GetMouseButtonDown(1))
        {
            RightMouseClick();
        }
    }

    private void LeftMouseClick()
    {

    }

    private void RightMouseClick()
    {

    }

    private void MoveCamera()
    {
        float xPos = Input.mousePosition.x;
        float yPos = Input.mousePosition.y;
        Vector3 movement = new Vector3(0, 0, 0);


        //Horizontal camera Movement
        if (xPos >= 0 && xPos < ResourceManager.ScrollWidth)
        {
            movement.x -= ResourceManager.ScrollSpeed;
        }
        else if (xPos <= Screen.width && xPos > Screen.width - ResourceManager.ScrollWidth)
        {
            movement.x += ResourceManager.ScrollSpeed;
        }

        //Vectical camera Movement
        if (yPos >= 0 && yPos < ResourceManager.ScrollWidth)
        {
            movement.z -= ResourceManager.ScrollSpeed;
        }
        else if (yPos <= Screen.height && yPos > Screen.height - ResourceManager.ScrollWidth)
        {
            movement.z += ResourceManager.ScrollSpeed;
        }

        //Make sure movement is in the direction the camera is pointing
        //but ignore the vertical titl of the camera to get sensible scrolling
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;

        //away from the ground movement
        movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");

        //Calculate desired camera position based on received input
        Vector3 origin = Camera.main.transform.position;
        Vector3 destination = origin;

        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;

        //Limit away from ground movement to be between a minimum and a maximum distance
        if (destination.y > ResourceManager.MaxCameraHeight)
        {
            destination.y = ResourceManager.MaxCameraHeight;
        }
        else if (destination.y < ResourceManager.MinCameraHeight)
        {
            destination.y = ResourceManager.MinCameraHeight;
        }

        //If a change in position is detected, perform the necessary update
        if (destination != origin)
        {
            Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
        }
    }

    private void RotateCamera()
    {
        Vector3 origin = Camera.main.transform.eulerAngles;
        Vector3 destination = origin;

        //Detect rotation amount if ALT is being held and the Right mouse is down
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetMouseButton(1))
        {
            destination.x -= Input.GetAxis("Mouse Y") * ResourceManager.RotateAmount;
            destination.y += Input.GetAxis("Mouse X") * ResourceManager.RotateAmount;
        }

        //If a change in position is detected, perform the necessary update
        if (destination != origin)
        {
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.RotateSpeed);
        }
    }
}
