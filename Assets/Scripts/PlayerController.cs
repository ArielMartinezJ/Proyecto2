using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    private Camera cam;

    PlayerMovement playerMovement;

	void Start ()
    {
        cam = Camera.main;
        playerMovement = GetComponent<PlayerMovement>();
	}
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                //Move our player to what we hit
                playerMovement.MoveToPoint(hit.point);
                //Stop focusing any objects

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                //Check if we hit an interactable
                //If we did, set it as our focus


            }
        }
    }
}
