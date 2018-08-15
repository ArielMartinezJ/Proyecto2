using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {

    public GameObject player;
    public float offset;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        this.transform.position = new Vector3(player.transform.localPosition.x, this.transform.localPosition.y, player.transform.localPosition.z - offset);
	}
}
