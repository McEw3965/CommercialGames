using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int randomNum;
    public Transform[] destinations;
    public catDetection CD;


    //cat movement

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //StartCoroutine(GenerateRandomNum()); //generate a random number very 40 seconds
    }


    private void Update()
    {
       // agent.destination = destinations[randomNum].position;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && CD.catDetected == false)
        {
            //StartCoroutine(GenerateRandomNum());
        }
    }

    IEnumerator GenerateRandomNum()
    {
        randomNum = Random.Range(0, destinations.Length);

        Debug.Log("Generated arndom number");
        agent.destination = destinations[randomNum].position;
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
