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
    public FireExManager FireExManager;
    public PlayerInteraction PlayerInteraction;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.onFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => motor.Jump();
        OnFoot.Crouch.performed += ctx => motor.Crouch();
        OnFoot.Sprint.performed += ctx => motor.Sprint();
        OnFoot.FireExtinguisher.performed += ctx => FireExManager.fireExtinguishActions();
        OnFoot.Interact.performed += ctx => PlayerInteraction.currentInteractable.Interact();
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