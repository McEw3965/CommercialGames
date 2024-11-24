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
    public PlayerControls interaction;
    private InputAction fireExtinguishAction;
    public PickUpItem pickup;
    public taskTerminal TT;
    public AudioSource fireExSound;
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
        if (pickup.itemInHand && pickup.currentItem.CompareTag("CanPickUp") && pickup.currentItem.name == "Fire_Ex") {
     
            pickup.SetPosition(new Vector3(0.5f, -1, 1));
            pickup.SetRotaion(new Vector3(-90, 0, 0));


            if (fireExtinguishAction.ReadValue<float>() > 0)
            {
                if (!particles.isPlaying)
                {
                    particles.Play();
                    fireExSound.Play();
                }
            }
            else
            {
                if (particles.isPlaying)
                {
                    particles.Stop();
                    fireExSound.Stop();
                }
            }
        }
    }
}

