using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; //reference to c# script
    public PlayerInput.OnFootActions OnFoot; //reference to onfootaction map;
    
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInteraction interaction;
    private PickUpItem pickUpItem;


    public FireExManager FireExManager;

    private bool hasFireEx = false;
   
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.onFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        interaction = GetComponent<PlayerInteraction>();
        pickUpItem = GetComponent<PickUpItem>();

        OnFoot.Jump.performed += ctx => motor.Jump();
        OnFoot.Crouch.performed += ctx => motor.Crouch();
        OnFoot.Sprint.performed += ctx => motor.Sprint();
        
        OnFoot.Interact.performed += ctx =>
        {
            if (interaction.currentInteractable == null)
            {
                Debug.Log("Current Interactable is null"); //this is to stop console warnings because when you drop an item, the currentInteractable is null
                return;
            }

            interaction.currentInteractable.Interact();
   
        };


        OnFoot.FireExtinguisher.performed += ctx =>
        {
            if (hasFireEx) //if the user is holding the fire extinguisher
            {
               
                FireExManager.fireExtinguishActions(); //then this works
            } else
            {
                //doesnt have the fire extinguisher picked up
                Debug.Log("Cannot spray particles as fire extinguisher is not picked up");
            }
        };

    }


    private void Update()
    {
        if (pickUpItem.currentItem != null)
        {
            if (pickUpItem.currentItem.name == "Fire_Ex")
            {
                hasFireEx = true;
            }
            else
            {
                hasFireEx = false; 
            }
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
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
        
    }
    private void LateUpdate()
    {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}