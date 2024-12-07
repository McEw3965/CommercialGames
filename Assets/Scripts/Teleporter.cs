using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private Transform player;
    private float timer = 0;
    private bool isTriggered;

    private void Start()
    {
        isTriggered = false;
    }
    private void Update()
    {
        if (isTriggered)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer > 2.5f)
            {
                Debug.Log("Moved the player to the destination! Teleported to: " + destination.position);
                player.position = destination.position;
             
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("on collision entered");
        if (other.GetComponent<CharacterController>())
        {
            Debug.Log("Collision with player");
            isTriggered = true;
            
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        timer = 0;
        isTriggered = false;
    }
  */
 
}
