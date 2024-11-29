using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PlayerDamage : MonoBehaviour
{
    public ventBehaviour[] ventBehaviour;

    [SerializeField] private GameObject hurtEffect;
    private AudioSource audioHurt;
    private taskTerminal TT;

    bool isHurt = false;
    bool isInFire = false;



    private void Start()
    {
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
        hurtEffect.SetActive(false);
        audioHurt = GetComponent<AudioSource>();


        if (audioHurt == null)
        {
            Debug.LogError("No AudioSource component found!");
        }
    }
    private void Update()
    {

        if (isInFire) 
        {
            Debug.Log("Player collided with fire!");

            if (!isHurt)
            {


                //post processing stuff
                hurtEffect.SetActive(true);
                audioHurt.Play();
                isHurt = true;                  
                          
            }
          
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Vent") && ventBehaviour[TT.ventNumber].isOnFire)
        {
            isInFire = true;
        }


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vent"))
        {
            isInFire = false;
            isHurt = false;

            Debug.Log("turn off effect");
            hurtEffect.SetActive(false);



        }

    }
}
