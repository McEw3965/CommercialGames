using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ventBehaviour : MonoBehaviour
{
    public GameObject fireEffects;

    private bool isOnFire = false;
    public taskTerminal TT;
    public AudioSource alarm;
    public Light mainLight;
    public MainUIManager UIManager;


    public void igniteVent()
    {
        if (!isOnFire)
        {
            isOnFire = true;
            fireEffects.SetActive(true);
            alarm.Play();
            print("Vent Ignited");
            mainLight.color = Color.red;
        }
    }

    public void repairVent()
    {
        if (isOnFire)
        {
            isOnFire = false;
            fireEffects.SetActive(false);
            alarm.Pause();
            print("Vent Repaired");
            TT.ventTaskActive = false;
            TT.eraseTaskList();
            mainLight.color = Color.white;
            UIManager.AdjustScore(50);

        }
    }
}
