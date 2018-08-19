using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour {

	public LayerMask bMask;

	private Transform currentBuilding;
	private Available available;
	private bool isPlaced;
	private Available availableX;
	private Building newBuilding;
	private Manager clickable;

	void Update () {

		Vector3 mPos = Input.mousePosition;
		mPos = new Vector3 (mPos.x, mPos.y, transform.position.y);
		Vector3 pos = Camera.main.ScreenToWorldPoint(mPos);

		if (currentBuilding != null && !isPlaced) {
			currentBuilding.position = new Vector3 (pos.x, 0, pos.z);

			if (Input.GetMouseButtonDown (0)) {
				if (IsAvailable ()) {
					isPlaced = true;
					clickable = gameObject.GetComponent<Manager>();
					clickable.SetClickable(true);
				}
			}
		} 
		else {
			if (Input.GetMouseButtonDown(0)){
				RaycastHit hit = new RaycastHit();
				Ray ray = new Ray(new Vector3(pos.x, 8, pos.z), Vector3.down);
				if (Physics.Raycast(ray, out hit, Mathf.Infinity, bMask)){
					if(availableX != null){
						availableX.SetSelected(false);
					}
					hit.collider.gameObject.GetComponent<Available>().SetSelected(true);
					availableX = hit.collider.gameObject.GetComponent<Available>();
				}
				else{
					if(availableX != null){
						availableX.SetSelected(false);
					}
				}
			}
		}
	}

	public void SetItem(GameObject g){
		isPlaced = false;
		currentBuilding = ((GameObject)Instantiate(g)).transform;
		available = currentBuilding.GetComponent<Available> ();

	}

	bool IsAvailable(){
		if (available.colliders.Count > 0) {
			return false;
		}
		return true;
	}
}
