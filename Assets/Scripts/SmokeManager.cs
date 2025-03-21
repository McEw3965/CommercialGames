using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    private taskTerminal TT;
    public ventBehaviour[] ventBehaviour;
    private void Start()
    {
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
    }
    private void OnParticleCollision(GameObject other)
    {
     //   Debug.Log("Collided with: " + other.name); 

        if (other.CompareTag("Vent") && other.GetComponent<ventBehaviour>().isOnFire) {  //if it is a vent, and the vent is on fire
            
            //repair the vent
            ventBehaviour[TT.ventNumber].repairVent();

        }

    }
}
