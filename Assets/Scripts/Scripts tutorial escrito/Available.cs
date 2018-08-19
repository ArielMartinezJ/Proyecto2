using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Available : MonoBehaviour {

	public List<Collider> colliders = new List<Collider>();

	private bool isSelected;
	private Building buildingClass;

	void Start () {
		buildingClass = GetComponent<Building> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Building") {
			colliders.Add(c);
		}
	}

	void OnTriggerExit(Collider c){
		if (c.tag == "Building") {
			colliders.Remove(c);
		}
	}

	public void SetSelected(bool b){
		isSelected = b;
	}

	void OnGUI(){
		if (isSelected) {
			GUI.Button(new Rect(100, 200, 100, 50), name);
		}
	}
}
