using UnityEngine;


//https://www.youtube.com/watch?si=hxdP8oWqMzjb322G&v=rJqP5EesxLk&feature=youtu.be video reference
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; //reference to c# script
    public PlayerInput.PlayerActions player; //reference to onfootaction map;
   // public PlayerInput.UIActions onUI;

    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInteraction interaction;
    private PickUpItem pickUpItem;

    public FireExManager FireExManager;
    public MapManager map;
    public TorchManager torch;
    //
    //public Dialogue dialogue;

    private bool hasFireEx = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        player = playerInput.Player;
       // onUI = playerInput.UI;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        interaction = GetComponent<PlayerInteraction>();
        pickUpItem = GetComponent<PickUpItem>();

        player.Jump.performed += ctx => motor.Jump();
        player.Crouch.performed += ctx => motor.Crouch();
        player.Sprint.performed += ctx => motor.Sprint();

        player.Interact.performed += ctx => //if E is pressed (for example)
        {

            if(interaction.currentInteractable == null && !pickUpItem.itemInHand) //return if there is no interactable object when E is pressed (stops crashes)
            {
                Debug.Log("There is no item to interact or pick up");
                return;
            }

            if(interaction.currentInteractable != null)
            {
                interaction.currentInteractable.Interact(); 
            }


            if (!pickUpItem.itemInHand) //if there is no item in hand
            {
                if (interaction.currentInteractable.CompareTag("CanPickUp")) //and the item the user is looking at has the tag can pick up
                {
                    Debug.Log("Picked up item");
                    pickUpItem.grabItem(); //pick up the item
                }

            }
            else // if item is in hand
            {
                if (pickUpItem.currentItem.GetComponent<Rigidbody>()) //if item is hand and the item has a rigidbody (needed for dropItem func)
                {
                    Debug.Log("Dropping Item");
                    pickUpItem.dropItem(); //drop the item
                }
            }
        };


        player.FireExtinguisher.performed += ctx =>
        {
            if (hasFireEx) //if the user is holding the fire extinguisher
            {

                FireExManager.fireExtinguishActions(); //then this works
            }
            else
            {
                //doesnt have the fire extinguisher picked up
                Debug.Log("Cannot spray particles as fire extinguisher is not picked up");
            }
        };


        player.DisplayMap.performed += ctx => map.ToggleMap(); //toggles the map on and off

        player.DisplayTorch.performed += ctx => torch.ToggleTorch();
       // onUI.Click.performed += ctx => dialogue.displayText();
    }


    private void Update()
    {
        if (pickUpItem.currentItem != null)
        {
            hasFireEx = pickUpItem.currentItem.name == "Fire_Ex";
        }
        else
        {
            hasFireEx = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movement action.
        motor.ProcessMove(player.Movement.ReadValue<Vector2>());

    }
    private void LateUpdate()
    {
        look.ProcessLook(player.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        player.Enable();
     //   onUI.Enable();
    }
    private void OnDisable()
    {
        player.Disable();
      //  onUI.Disable();

    }
}