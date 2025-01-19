using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int randomNum;
    public Transform[] destinations;
    private catDetection CD;
    private GameObject alien;
    private Animator animator;
    private bool isCatSitting = false;
   


    //cat movement

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        alien = GameObject.Find("Waving Alien");
        CD = alien.GetComponent<catDetection>();

        StartCoroutine(GenerateRandomNum()); //generate a random number very 40 seconds
        StartCoroutine(catSits());
    }


    private void Update()
    {
        // agent.destination = destinations[randomNum].position;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !CD.catPickedUp)
        {
            StartCoroutine(GenerateRandomNum());
        } else if (CD.catPickedUp)
        {
            agent.destination = alien.transform.position;
        }

        // FaceTarget();

    }


    IEnumerator catSits()
    {
        if (agent != null && agent.enabled)
        
            {
            while (true)
            {
                yield return new WaitForSeconds(15f); //if its been 15 seconds then the cat sits

                isCatSitting = true;
                animator.SetBool("isSitting", isCatSitting);
               agent.isStopped = true;

                yield return new WaitForSeconds(10f); //the cat walks after 10 seconds
                isCatSitting = false;
                agent.isStopped = false;
                animator.SetBool("isSitting", isCatSitting);
               
            }
        }
    }
    IEnumerator GenerateRandomNum()
    {
        if (!CD.catPickedUp)
        {


            if (!isCatSitting)
            {
                randomNum = Random.Range(0, destinations.Length);

                Debug.Log("Generated arndom number");
                agent.destination = destinations[randomNum].position;
                yield return new WaitForSeconds(10f);
            }
        }
    }


    private void FaceTarget()
    {
        /*
        Vector3 targetPosition = agent.steeringTarget;
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        agent.velocity = direction * agent.speed;
        */
    }
   }

