using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public ventBehaviour[] ventBehaviour;

    private Animator animator;
    private AudioSource audioHurt;
    private taskTerminal TT;
    
    bool isHurt = false;
    bool isInFire = false;
    float time = 0;


    private void Start()
    {
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
        animator = GameObject.Find("Post Processing Hurt Effect").GetComponent<Animator>();
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
                animator.SetBool("IsHurt", true);
                audioHurt.Play();
                isHurt = true;                  
                time = 0f;                    
            }
            else
            {
                turnoffhurtanimation();
            }
        }
    }

    void turnoffhurtanimation()
    {
        time = 0;
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            animator.SetBool("IsHurt", false);
            isHurt = false;
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
            turnoffhurtanimation();


        }
       
    }
}
