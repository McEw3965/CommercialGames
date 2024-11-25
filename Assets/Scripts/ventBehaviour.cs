using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ventBehaviour : MonoBehaviour
{
    public GameObject fireEffects;
    public bool isOnFire = false;
    private taskTerminal TT;
    public AudioSource alarm;
    public Light mainLight;
    public MainUIManager UIManager;

    private void Start()
    {
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();

    }
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
            TT.removeFromList("TaskVent");
            mainLight.color = Color.white;
            UIManager.AdjustScore(50);

        }
    }
}
