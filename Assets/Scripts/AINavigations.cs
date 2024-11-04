using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigations : MonoBehaviour
{
    public List<Transform> waypoints;
    NavMeshAgent agent;
    public int currentWaypoint = 0;
    public GameObject Player;
    public bool canFollowPlayer = false;

    public float stopDistance = 10f;

    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFollowPlayer) 
        {
            patrol();
        }   
    }

    public void patrol() 
    {
        /*
        if (waypoints.Count == 0) 
        {
            return;
        }

        float distanceToWaypoints = Vector3.Distance(waypoints[currentWaypoint].position, transform.position);

        if (distanceToWaypoints <= 2)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
        */
        float distanceToDestination = Vector3.Distance(transform.position, destination.transform.position);
        if (distanceToDestination <= 2) 
        {
            canFollowPlayer = false;
            ReachDestination();
        }

        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer > stopDistance)
        {
            agent.SetDestination(Player.transform.position);
        }
        else 
        {
            ReachDestination();
        }

    }

    public void ReachDestination() 
    {
        agent.ResetPath();
    }
}
