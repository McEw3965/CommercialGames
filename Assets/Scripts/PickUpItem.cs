using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem : MonoBehaviour
{
    public Camera playerCamera; // The player's camera
    public float interactionRange = 5f; 
    public GameObject currentItem;
    public bool itemInHand = false; //this is being used in the fire ex manager script



    //unity new input system:
    public PlayerControls interaction;
    private InputAction dropItemBtn;

    private void Awake()
    {
        interaction = new PlayerControls();
    }
    private void OnEnable()
    {
        dropItemBtn = interaction.Player.DropItem;
        dropItemBtn.Enable();
    }

    private void OnDisable()
    {
        dropItemBtn.Disable();
    }

    void Update()
    {
        if (!itemInHand) //if there is nothing in the players hand
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
            { 
                if (hit.collider != null)
                {
                    currentItem = hit.collider.gameObject; //currentItems are being discovered based on where the player is looking
                                                           //and that is being updated until they have picked up that item
                }
            }
        }

        if (dropItemBtn.ReadValue<float>() > 0) //if player right clicks
        {
            if (currentItem.GetComponent<Rigidbody>()) //check if the current item has a rigidbody first to stop any errosr
            {
                //drop item
                dropItem(currentItem.GetComponent<Rigidbody>());
            }
        }
    }

   //this is being called with interaction script
    public void grabItem()
        {
          if (!itemInHand) //picked up
          {

              if (currentItem.CompareTag("Interactable")) //if the item is interactable
              {
                  itemInHand = true;
             
                   Rigidbody itemRigidbody = currentItem.GetComponent<Rigidbody>();

                  if (itemRigidbody != null)
                  {
                      itemRigidbody.isKinematic = true;
                  }

                  //positions where the item is picked up in the camera view
                  currentItem.transform.SetParent(playerCamera.transform);
                  currentItem.transform.localPosition = new Vector3(0.5f, -1, 1);
                  currentItem.transform.localRotation = Quaternion.Euler(-90, 0, 0);
              }

          }
       }

       //drops the item
    void dropItem(Rigidbody currentItem)
    {
            Debug.Log("Dropitem running");
            currentItem.isKinematic = false;
            currentItem.velocity = Vector3.zero;
            currentItem.transform.SetParent(null);
            itemInHand = false;
    }
}
