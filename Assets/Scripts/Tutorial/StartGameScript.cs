using UnityEngine;
using UnityEngine.AI;

public class StartGameScript : MonoBehaviour
{
    public bool tutorialOn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject alien;
    [SerializeField] private GameObject tasks;
    [SerializeField] private Dialogue dialogue;
    private void Start()
    {
        tutorialOn = true;
    }

    private void Update()
    {
        if(tutorialOn)
        {
            player.GetComponent<InputManager>().enabled = false;
            alien.GetComponent<AlienMovement>().enabled = false;
            alien.GetComponent<Animator>().enabled = false;
            alien.GetComponent<NavMeshAgent>().enabled = false;
            tasks.GetComponent<taskTerminal>().enabled = false;
           
        }

        if(!dialogue.dialogueon)
        {
            tutorialOn=false;
            player.GetComponent<InputManager>().enabled = true;
            alien.GetComponent<AlienMovement>().enabled = true;
            alien.GetComponent<Animator>().enabled = true;
            alien.GetComponent<NavMeshAgent>().enabled = true;
            tasks.GetComponent<taskTerminal>().enabled = true;

        }


    }
}
