using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public Animator animator;
    float time = 0;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("ParticleCollision");
        if(other.CompareTag("Player"))
        {
            bool isHurt = animator.GetBool("isHurt");

            Debug.Log("Player collided with fire!");

            time += Time.deltaTime;

            animator.SetBool("isHurt", isHurt);

            if (time >= 5)
            {
                animator.SetBool("isHurt", !isHurt);
            }
        }
    }
}
