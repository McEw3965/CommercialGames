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
    public bool itemInHand = false;
    public bool isPickedUp = false;

    void Update()
    {
        if (!itemInHand)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
            {
                if (hit.collider != null)
                {
                    currentItem = hit.collider.gameObject;
                }
            }
        }
    }


    //this is being called with interaction script
    public void pickUpItem()
    {
        Rigidbody itemRigidbody = null;

        if (!itemInHand) //picked up
        {
           
                if (currentItem.CompareTag("Interactable"))
                {
                    itemInHand = true;
                    //isPickedUp = true;
                    itemRigidbody = currentItem.GetComponent<Rigidbody>();

                    if (itemRigidbody != null)
                    {
                        itemRigidbody.isKinematic = true;
                    }

                    currentItem.transform.SetParent(playerCamera.transform);
                    currentItem.transform.localPosition = new Vector3(0.5f, -1, 1);
                    currentItem.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                }
       
        } else //drop?
        {
            Debug.Log("DropItem called");
            dropItem(itemRigidbody);
            ///isPickedUp = false;
            //itemInHand = false;
        }
    }



    //this is then being called with E 
    void dropItem(Rigidbody currentItem)
    {
        Debug.Log("Dropitem running");
            currentItem.isKinematic = false;
            currentItem.velocity = Vector3.zero;
            currentItem.transform.SetParent(null);
            itemInHand = false;
    }
}
