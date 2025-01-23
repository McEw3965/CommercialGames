using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;


public class AlienMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    private int randomNum;
    public Transform[] destinations;
    public catDetection CD;
    private GameObject hole;
    private GameObject holeCentre;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hole = GameObject.Find("Hole Destination");
        holeCentre = GameObject.Find("Hole Marker");
        GenerateRandomNum();
    }


    private void Update()
    {
        if (!CD.catPickedUp)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                GenerateRandomNum();
            }
        } else //cat is picked up
        {
            agent.destination = hole.transform.position;

           // destinations = new Transform[] { hole.transform };
            Debug.Log("destination changed to:" + agent.destination);

          //  GenerateRandomNum();

            if (agent.remainingDistance <= agent.stoppingDistance && CD.catPickedUp)
            {
                Debug.Log("Reached hole destination");
                this.gameObject.transform.LookAt(holeCentre.transform.position);
                // CD.holdCatOverHole();                
            }
        }
        
          
    }

    public void GenerateRandomNum()
    {
        if (!CD.catPickedUp)
        {
            randomNum = Random.Range(0, destinations.Length);

            agent.destination = destinations[randomNum].position;
            Debug.Log("destination changed to:" + agent.destination);
        }
     
    }

}
