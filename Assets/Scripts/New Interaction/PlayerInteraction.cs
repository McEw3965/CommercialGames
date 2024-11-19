using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    public PlayerControls interaction;
    private InputAction interact;


    private void Awake()
    {
        interaction = new PlayerControls();
    }


    private void OnEnable()
    {
        interact = interaction.Player.Interact;
        interact.Enable();
    }

    private void OnDisable()
    {
        interact.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (interact.triggered && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if(Physics.Raycast(ray, out hit, playerReach)) {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>(); 
                
               if(currentInteractable && newInteractable != null)
                {
                    currentInteractable.DisableOutline(); 
                }
            if(newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                } else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
         } 
        else
        {
            DisableCurrentInteractable();
        }
    }

     void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        UIController.Instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        UIController.Instance.DisableInteractionText();
        if(currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
