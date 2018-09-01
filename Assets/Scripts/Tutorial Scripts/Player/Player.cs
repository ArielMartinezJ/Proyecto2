using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string username;
    public bool isHuman = false;

    public HUD hud;

    public WorldObject SelectedObject { get; set; }

	void Start ()
    {
        hud = GetComponentInChildren<HUD>();	
	}
	
	void Update ()
    {
		
	}
}
