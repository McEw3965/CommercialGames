using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;


public class AlienMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int randomNum;
    public Transform[] destinations;
    public catDetection CD;
    private GameObject hole;
    private GameObject holeCentre;


    //cat movement

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(GenerateRandomNum()); //generate a random number very 40 seconds
        hole = GameObject.Find("Hole Destination");
        holeCentre = GameObject.Find("Hole Marker");
    }


    private void Update()
    {

      
            //agent.destination = destinations[randomNum].position;

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && CD.catDetected == false)
            {
                StartCoroutine(GenerateRandomNum());
            }
            else if (CD.catPickedUp)
            {
                agent.destination = hole.transform.position;
            }

            if (agent.remainingDistance <= agent.stoppingDistance && CD.catPickedUp)
            {
                //this.gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, holeCentre.transform.rotation, 3f);
                this.gameObject.transform.LookAt(holeCentre.transform.position);
                CD.holdCatOverHole();
                //CD.throwCat();
            }
        
    }

    IEnumerator GenerateRandomNum()
    {
  
        randomNum = Random.Range(0, destinations.Length);
        

        agent.destination = destinations[randomNum].position;
        Debug.Log("destination changed to:" + agent.destination);

        yield return new WaitForSeconds(10f);
    }

    private void grabCat()
    {
        Vector3 catPos = CD.passCatPos();

        agent.destination = catPos;

        if (this.transform.position == catPos)
        {
            CD.catPickedUp = true;
        }
    }

}
