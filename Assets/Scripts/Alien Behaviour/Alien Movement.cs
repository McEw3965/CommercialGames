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

    private float time = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hole = GameObject.Find("Hole Destination");
        holeCentre = GameObject.Find("Hole Marker");
        GenerateRandomNum();
    }


    private void Update()
    {
        time += Time.deltaTime;
        if (!CD.catPickedUp)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                GenerateRandomNum();
                time = 0;
            }

            if(time > 15) //this is to try and make the alien be unstuck
            {
                GenerateRandomNum();
                time = 0;
            }



        } else //cat is picked up
        {
            agent.destination = hole.transform.position;

            Debug.Log("destination changed to:" + agent.destination);


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
