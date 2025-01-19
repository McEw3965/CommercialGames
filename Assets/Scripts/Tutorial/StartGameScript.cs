using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class StartGameScript : MonoBehaviour
{
    public bool tutorialOn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject alien;
    [SerializeField] private GameObject tasks;
    [SerializeField] private StartDialogue dialogue;
    [SerializeField] private GameObject interactionText;
    [SerializeField] private Transform lightSwitchlocation;
    [SerializeField] private TutorialTrigger playerTrigger;
    [SerializeField] private TutorialTrigger alienTrigger;
    [SerializeField] private Transform[] position;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject cat;


    [SerializeField] private GameObject timer;
 

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
                if (!playerTrigger.isPlayerInside)
                {
                    player.GetComponent<InputManager>().enabled = false;
                    alien.GetComponent<AlienMovement>().enabled = false;
                    alien.GetComponent<Animator>().enabled = false;
                    alien.GetComponent<NavMeshAgent>().enabled = false;
                    alien.GetComponent<Interactable>().enabled = false;
                  //  interactionText.SetActive(false);
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
              //  interactionText.SetActive(true);


                if (!playtaskonce)

                {
                    tasks.GetComponent<taskTerminal>().selectspecifictask(3);

                    playtaskonce = true;
                }

                /*if (playonce && alien.GetComponent<NavMeshAgent>().remainingDistance <= alien.GetComponent<NavMeshAgent>().stoppingDistance)
                {
                    alien.GetComponent<NavMeshAgent>().isStopped = true;
                }*/

                if (alienTrigger.isAlienInside)
                {
                    //alien.GetComponent<AlienMovement>().destinations = new Transform[] { playerTrigger.GetComponent<Transform>() };

                    alien.GetComponent<Transform>().LookAt(playerTrigger.GetComponent<Transform>());
                    alien.GetComponent<NavMeshAgent>().isStopped = true;
                    alien.GetComponent<Rigidbody>().isKinematic = true;
                    alien.GetComponent<Animator>().enabled = false;
                    //Debug.Log("Alien Inside");
                }

                if (playerTrigger.isPlayerInside && alienTrigger.isAlienInside)
                {
                    //alien.GetComponent<NavMeshAgent>().isStopped = true;
                    //alien.GetComponent<Rigidbody>().isKinematic = true;
                    //alien.GetComponent<Transform>().LookAt(player.GetComponent<Transform>().position);
                    //alien.GetComponent<Transform>().rotation = Quaternion.Euler(0f, alien.GetComponent<Transform>().rotation.y, 0f);
                    //alien.GetComponent<AlienMovement>().destinations = new Transform[] { playerModel.GetComponent<Transform>() };

                    //alien.GetComponent<Animator>().enabled = false;
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


                        if (playonce && tasks.GetComponent<taskTerminal>().lightTaskActive == false)
                    {

                        dialogue.gameObject.SetActive(false);
                        alien.GetComponent<NavMeshAgent>().isStopped = false;
                        alien.GetComponent<Rigidbody>().isKinematic = false;
                        alien.GetComponent<Animator>().enabled = true;
                        player.GetComponent<InputManager>().enabled = true;
                        alien.GetComponent<NavMeshAgent>().enabled = true;
                       // alien.GetComponent<Interactable>().enabled = true;
                        alien.GetComponent<AlienMovement>().destinations = new Transform[]
                        {
                              position[0], position[1], position[2],position[3]
                        };


                        playerTrigger.gameObject.SetActive(false);
                        alienTrigger.gameObject.SetActive(false);
                        tutorialOn = false;
                        timer.GetComponent<Timer>().timerOn = true;
                        timer.SetActive(true);
                       cat.SetActive(true);// cat is currently causing bug problem
                      
                    }
                }
            }
        }


    }
}
