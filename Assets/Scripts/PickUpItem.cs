using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem : MonoBehaviour
{
    Camera playerCamera; // The player's camera
    public float interactionRange = 5f;
    public GameObject currentItem;
    public bool itemInHand = false; //this is being used in the fire ex manager script

    Vector3 originalScale;

    private void Start()
    {
        playerCamera = Camera.main;
        itemInHand = false;
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
    }

    public void SetPosition(Vector3 position)
    {
        currentItem.transform.localPosition = position;
    }

    public void SetRotaion(Vector3 rotation)
    {
        currentItem.transform.localRotation = Quaternion.Euler(rotation);
    }


    //this is being called with interaction script
    public void grabItem()
    {

        if (currentItem != null && currentItem.CompareTag("CanPickUp"))
        {
            itemInHand = true;

            Rigidbody itemRigidbody = currentItem.GetComponent<Rigidbody>();

            if (itemRigidbody != null)
            {
                itemRigidbody.isKinematic = true;
            }

            Collider itemCollider = currentItem.GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.enabled = false; // Disable collisions
            }

            originalScale = currentItem.transform.localScale;
            currentItem.transform.SetParent(playerCamera.transform);
            currentItem.transform.localScale = originalScale; // Restore original scale


        }
    }

    //drops the item
    public void dropItem()
    {
        if (currentItem != null)
        {
            Rigidbody itemRigidbody = currentItem.GetComponent<Rigidbody>();

            if (itemRigidbody != null)
            {
                itemRigidbody.isKinematic = false;
                itemRigidbody.velocity = Vector3.zero;
            }

            Collider itemCollider = currentItem.GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.enabled = true;
            }

            // Unparent the item
            currentItem.transform.SetParent(null);
            currentItem.transform.localScale = originalScale;

            currentItem = null;
            itemInHand = false;
        }
    }

}
