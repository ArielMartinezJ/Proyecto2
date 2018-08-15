using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    #region Public Variables
    [Header("\t--Public Variables--")]
    public Vector3 initialSpawnPosition;
    public bool checkpointPassed = false;
    public Vector3 spawnPosition;
    #endregion
    private Vector3 newPosition;
    public Vector3 forward;
    
    private bool alreadyPassed = false;

    [SerializeField]
    private AudioSource checkpointSound;

    void Awake ()
    {
        initialSpawnPosition = new Vector3(-66.16f, 17.3f, 57.02f);
    }

	void Start ()
    {	
	}
	
	void Update ()
    {
        //initialSpawnPosition = newPosition;
        //Debug.Log("Current Spawn Position: " + spawnPosition);

        /*if (HealthScript.iAmrestarting)
        {
            checkpointPassed = false;
        }*/
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Checkpoint passed");
            GameManager.Instance.SetLastCheckpointPosition(this.transform.position);
            Debug.Log("this position" + this.transform.position);
            /*checkpointPassed = true;
            newPosition = this.gameObject.transform.position;
            forward = this.gameObject.transform.forward;*/
            /*if (!alreadyPassed)
            {
                checkpointSound.Play();
            }
            alreadyPassed = true;*/
        }
    }
}


