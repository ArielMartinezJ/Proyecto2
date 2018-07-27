using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static InputManager myInstance;

    public static InputManager Instance
    {
        get { return myInstance; }
    }

    private void Awake()
    {
        if (myInstance != null && myInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        myInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private float escapeValue = 1;

    void Start () {
		
	}
	
	void Update ()
    {
		
	}

    public bool EscapeHasBeenPressed()
    {
        Debug.Log("Escape has been pressed");
        if (Input.GetAxis("Cancel") == 1)
        {
            return true;
        } else
        {
            return false;
        }
        //return escapeValue == Input.GetAxis("Cancel");
    }
}
