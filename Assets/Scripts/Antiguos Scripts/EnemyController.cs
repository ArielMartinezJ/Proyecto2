using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour {

#region Public Variables
    public enum State { GOING, REACHING, WAITING }
    public State currentState = State.WAITING;
    public float waitingTime = 1f;
    public float elapsedTime;
    public float wanderRadius = 5f;
    public LayerMask dangerZones;
    public NavMeshAgent enemy;
    #endregion

    private Vector3 newPosition;

    void Start ()
    {
        enemy = GetComponent<NavMeshAgent>();
	}
	

	void Update ()
    {
		switch (currentState)
        {
            case State.WAITING:
                if (elapsedTime > waitingTime)
                {
                    newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
                    enemy.destination = newPosition;
                    Debug.Log("Changing to going");
                    ChangeState(State.GOING);
                }
                elapsedTime += Time.deltaTime;
                break;

            case State.GOING:
                
                if ((this.transform.position - newPosition).magnitude < 0.01f)
                {
                    Debug.Log("Changing to waiting");
                    ChangeState(State.WAITING);
                }
                break;

            case State.REACHING:
                break;

        }
	}

    private void ChangeState(State newState)
    {
        //EXIT STATE LOGIC
        switch (currentState)
        {
            case State.WAITING:
                elapsedTime = 0;
                break;

            case State.GOING:
                break;

            case State.REACHING:
                break;
        }

        //ENTER STATE LOGIC
        switch (newState)
        {
            case State.WAITING:
                break;

            case State.GOING:
                break;

            case State.REACHING:
                break;
        }
        currentState = newState;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomPosition = Random.insideUnitSphere * distance;

        randomPosition += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomPosition, out navHit, distance, layermask);

        return navHit.position;
    }
}
