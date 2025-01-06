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


    private void Start()
    {
        tutorialOn = true;
       
    }

    private void Update()
    {
        if(dialogue.dialogueon)
        {
            player.GetComponent<InputManager>().enabled = false;
            alien.GetComponent<AlienMovement>().enabled = false;
            alien.GetComponent<Animator>().enabled = false;
            alien.GetComponent<NavMeshAgent>().enabled = false;
            alien.GetComponent<Interactable>().enabled = false;

            interactionText.SetActive(false);


        }

        if (!dialogue.dialogueon)
        {
            //   tutorialOn=false;
            player.GetComponent<InputManager>().enabled = true;
            alien.GetComponent<AlienMovement>().enabled = true;

            alien.GetComponent<AlienMovement>().destinations = new Transform[] { lightSwitchlocation };
         


            alien.GetComponent<Animator>().enabled = true;
            alien.GetComponent<NavMeshAgent>().enabled = true;
            alien.GetComponent<Interactable>().enabled = true;
            interactionText.SetActive(true);


            tasks.GetComponent<taskTerminal>().selectspecifictask(3);



         
            if (trigger.isPlayerInside && trigger.isAlienInside)
            {
                dialogue.gameObject.SetActive(true);
                dialogue.lines = new string[]
                {
                    "This is the light switch",
                    "To be able to see better, press R to bring up your torch",
                    "Pressing the buttons should fix the problem!",
                };

                dialogue.StartDialogues();
            }
        }


    }
}
