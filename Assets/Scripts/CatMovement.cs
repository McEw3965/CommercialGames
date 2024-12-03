using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int randomNum;
    public Transform[] destinations;

    //cat movement

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(GenerateRandomNum()); //generate a random number very 40 seconds
    }


    private void Update()
    {
        agent.destination = destinations[randomNum].position;
    }

    IEnumerator GenerateRandomNum()
    {
        randomNum = Random.Range(0, destinations.Length);

        Debug.Log("Generated arndom number");
        yield return new WaitForSeconds(40f);
    }

}
