using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireExManager : MonoBehaviour
{
    public ParticleSystem particles;
    public ventBehaviour vb;
    public PlayerControls interaction;
    private InputAction fireExtinguishAction;
    public PickUpItem pickup;

    private void Awake()
    {
        interaction = new PlayerControls();
    }
    private void OnEnable()
    {
        fireExtinguishAction = interaction.Player.FireExtinguisher;
        fireExtinguishAction.Enable();
    }

    private void OnDisable()
    {
        fireExtinguishAction.Disable();
    }


    void Start()
    {
        particles.Stop();
    }
    void Update()
    {
 
        if(pickup.itemInHand && this.GetComponent<FireExManager>() != null) //make it so if the fire ex has this script and picked up
        if (fireExtinguishAction.ReadValue<float>() > 0) 
        {
            if (!particles.isPlaying)
            {
                particles.Play();
             //   Debug.Log("Particles started");
            }
        }
        else
        {
            if (particles.isPlaying)
            {
                particles.Stop();
           //     Debug.Log("Particles stopped");
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit Particle");

        if(vb.isOnFire)
        {
            vb.repairVent();
        }
    }

}

