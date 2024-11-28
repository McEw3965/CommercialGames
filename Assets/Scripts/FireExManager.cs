using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;

public class FireExManager : MonoBehaviour
{
    public ParticleSystem particles;
    public ventBehaviour[] ventBehaviour;
    public PickUpItem pickup;
    private taskTerminal TT;
    public AudioSource fireExSound;
   
    void Start()
    {
        particles.Stop();
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();

    }
    void Update()
    {
        if (pickup.itemInHand && pickup.currentItem.CompareTag("CanPickUp") && pickup.currentItem.name == "Fire_Ex")
        {

            pickup.SetPosition(new Vector3(0.5f, -1, 1));
            pickup.SetRotaion(new Vector3(-90, 0, 0));
        }
    }


  public void fireExtinguishActions() //function called on left mouse click 
    {
        if (!particles.isEmitting)
        {
            Debug.Log("Playing particles and sound...");

            particles.Play();
            fireExSound.Play();
        }
        else
        {
            Debug.Log("Stopping particles and sound...");

            particles.Stop();
            fireExSound.Stop();
        }
    }
}

