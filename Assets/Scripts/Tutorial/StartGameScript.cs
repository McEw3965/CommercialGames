using UnityEngine;
using UnityEngine.AI;

public class StartGameScript : MonoBehaviour
{
    public bool tutorialOn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject alien;
    [SerializeField] private GameObject tasks;
    [SerializeField] private StartDialogue dialogue;
    [SerializeField] private GameObject interactionText;
    [SerializeField] private Transform lightSwitchlocation;
    [SerializeField] private TutorialTrigger trigger;
    [SerializeField] private Transform[] position;
    [SerializeField] private NavMeshAgent agent;




    private bool playonce = false;
    private bool playtaskonce = false;

    private void Start()
    {
        tutorialOn = true;

    }

    private void Update()
    {

        if (tutorialOn)
        {

            if (dialogue.dialogueon)
            {
                if (!trigger.isPlayerInside)
                {
                    player.GetComponent<InputManager>().enabled = false;
                    alien.GetComponent<AlienMovement>().enabled = false;
                    alien.GetComponent<Animator>().enabled = false;
                    alien.GetComponent<NavMeshAgent>().enabled = false;
                    alien.GetComponent<Interactable>().enabled = false;
                    interactionText.SetActive(false);
                }

            }

            if (!dialogue.dialogueon)
            {
                player.GetComponent<InputManager>().enabled = true;
                alien.GetComponent<AlienMovement>().enabled = true;

                alien.GetComponent<AlienMovement>().destinations = new Transform[] { lightSwitchlocation };



                alien.GetComponent<Animator>().enabled = true;
                alien.GetComponent<NavMeshAgent>().enabled = true;
                alien.GetComponent<Interactable>().enabled = true;
                interactionText.SetActive(true);


                if (!playtaskonce)

                {
                    tasks.GetComponent<taskTerminal>().selectspecifictask(3);

                    playtaskonce = true;
                }

                if (alien.GetComponent<NavMeshAgent>().remainingDistance <= alien.GetComponent<NavMeshAgent>().stoppingDistance)
                {
                    alien.GetComponent<NavMeshAgent>().isStopped = true;
                }


                if (trigger.isPlayerInside)
                {

                    alien.GetComponent<Animator>().enabled = false;
                    //    alien.transform.position = lightSwitchlocation.position;
                    dialogue.gameObject.SetActive(true);
                    dialogue.lines = new string[]
                    {
                    "This is the light switch",
                    "To be able to see better, press R to bring up your torch",
                    "Pressing the button on the wall should fix the problem!",
                    };

                    if (!playonce)
                    {
                        dialogue.StartDialogues();
                        playonce = true;
                    }

                    if (playonce && agent.remainingDistance <= agent.stoppingDistance)
                    {
                        Debug.Log("Alien Stopped");
                    }


                        if (playonce && tasks.GetComponent<taskTerminal>().lightTaskActive == false)
                    {

                        dialogue.gameObject.SetActive(false);
                        alien.GetComponent<NavMeshAgent>().isStopped = false;
                        alien.GetComponent<Animator>().enabled = true;
                        alien.GetComponent<AlienMovement>().destinations = new Transform[]
                        {
                              position[0], position[1], position[2],position[3]
                        };




                        trigger.gameObject.SetActive(false);
                        tutorialOn = false;

                    }
                }
            }
        }


    }
}
