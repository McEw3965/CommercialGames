using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    public taskTerminal TT;
    public ventBehaviour[] ventBehaviour;


    private void OnParticleCollision(GameObject other)
    {
     //   Debug.Log("Collided with: " + other.name); 

        if (other.CompareTag("Vent") && other.GetComponent<ventBehaviour>().isOnFire) {  //if it is a vent, and the vent is on fire
            
            //repair the vent
            ventBehaviour[TT.ventNumber].repairVent();

        }

    }
}
