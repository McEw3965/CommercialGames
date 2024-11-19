using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Camera playerCamera; // The player's camera
    public float interactionRange = 5f; // How far the player can interact with an object
    private GameObject currentItem; // The current item the player is interacting with
    public bool isPickedUp = false;

    void Update()
    {
        // Cast a ray from the camera's position to where the player is looking
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
        {
            // If the ray hits an object, set it as the current item
            if (hit.collider != null)
            {
                currentItem = hit.collider.gameObject; // Store the object that was hit
            }
        }
    }

    // Call this method when the player presses E to interact with the item
    public void pickUpItem()
    {
        if (currentItem != null)
        {
            isPickedUp = !isPickedUp; // Toggle the pickup status

            Rigidbody itemRigidbody = currentItem.GetComponent<Rigidbody>(); // Get the Rigidbody of the object

            if (isPickedUp)
            {
                // Pick up logic
                if (itemRigidbody != null)
                {
                    itemRigidbody.isKinematic = true; // Disable physics interaction
                }

                // Parent the item to the camera and adjust its position
                currentItem.transform.SetParent(playerCamera.transform);
                currentItem.transform.localPosition = new Vector3(0, 0, 2); // Adjust position relative to camera
            }
            else
            {
                // Drop logic
                if (itemRigidbody != null)
                {
                    itemRigidbody.isKinematic = false; // Enable physics interaction
                    itemRigidbody.velocity = Vector3.zero; // Optionally, reset velocity to stop movement when dropped
                }

                // Unparent the item from the camera
                currentItem.transform.SetParent(null);
            }
        }
    }
}
