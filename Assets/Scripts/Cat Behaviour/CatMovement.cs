using System.Collections;
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
    public AudioSource meow;
    public AudioSource purring;


    //cat movement

    private void Start()
    {


        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        alien = GameObject.Find("Waving Alien");
        CD = alien.GetComponent<catDetection>();

        StartCoroutine(catSits());
        StartCoroutine(meowing());


    }


    private void Update()
    {

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !CD.catPickedUp)
        {
            GenerateRandomNum();
        }
        else if (CD.catPickedUp)
        {
            agent.destination = alien.transform.position;
        }



    }

    IEnumerator meowing()
    {

        meow.Play();
        yield return new WaitForSeconds(5f);

    }
    IEnumerator catSits()
    {


        if (gameObject.GetComponent<NavMeshAgent>().enabled)
        {
            yield return new WaitForSeconds(15f); //if its been 15 seconds then the cat sits
            purring.Play();
            isCatSitting = true;
            animator.SetBool("isSitting", isCatSitting);
            agent.isStopped = true;



            yield return new WaitForSeconds(10f); //the cat walks after 10 seconds
            purring.Stop();
            isCatSitting = false;
            agent.isStopped = false;
            animator.SetBool("isSitting", isCatSitting);
        }

    }
   public void GenerateRandomNum()
    {
        Debug.Log("destination changed to:" + agent.destination);
        randomNum = Random.Range(0, destinations.Length);
        agent.destination = destinations[randomNum].position;
    
    }
}
