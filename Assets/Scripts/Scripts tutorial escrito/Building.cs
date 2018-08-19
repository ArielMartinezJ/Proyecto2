using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Building : MonoBehaviour {
	
	public class Buildings{
		
		public int health;
		public string name;
		public GameObject avatar;

		public Buildings(int _health, string _name, GameObject _avatar){
			health = _health;
			name = _name;
			avatar = _avatar;
			
		}
	}
	public List<Buildings> buildingList = new List<Buildings>();
	public Buildings newBuilding;
	public GameObject[] buildings;
	
	void Start(){

		for (int i = 0; i < buildings.Length; i ++) {
			newBuilding = new Buildings (100, buildings[i].name, buildings[i] );
			buildingList.Add(newBuilding);
		}

		Debug.Log (buildingList[0].health);
	}
}
