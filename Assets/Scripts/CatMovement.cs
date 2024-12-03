using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class CatMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int randomNum;
    public Transform[] destinations;
    private float speed = 2f;

    //cat movement

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(GenerateRandomNum()); //generate a random number very 40 seconds
    }


    private void Update()
    {
        // agent.destination = destinations[randomNum].position;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(GenerateRandomNum());
        }

        FaceTarget();

    }

    IEnumerator GenerateRandomNum()
    {
        randomNum = Random.Range(0, destinations.Length);

        //Debug.Log("Generated arndom number");
        agent.destination = destinations[randomNum].position;
        yield return new WaitForSeconds(10f);
    }


    private void FaceTarget()
    {
        Vector3 targetDirection = destinations[randomNum].position - transform.position;
        Debug.Log(targetDirection);

        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);

        /*
        Vector3 FacingAngle;
        FacingAngle.x = this.gameObject.transform.rotation.x;
        FacingAngle.y = this.gameObject.transform.rotation.y;
        FacingAngle.z = this.gameObject.transform.rotation.z;

        float angleToDest = Vector3.Angle(FacingAngle, destinations[randomNum].position);

        Debug.Log("Angle = " + angleToDest);

        this.gameObject.transform.rotation = ;
        */
    }
   }

