using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ventBehaviour : MonoBehaviour
{
    public GameObject fireEffects;
    public bool isOnFire = false;
    private taskTerminal TT;
   // public AudioSource alarm;
    public MainUIManager UIManager;
    public FlashingLights flashinglights;
    [SerializeField] private Timer timer;
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
        
            print("Vent Ignited");
        }
    }

    public void repairVent()
    {
        if (isOnFire)
        {
            isOnFire = false;
            fireEffects.SetActive(false);
            //alarm.Stop();
           // TT.speakers[TT.ventNumber].Stop();
            print("Vent Repaired");
            TT.ventTaskActive = false;
            TT.alarmTaskActive = false;
            flashinglights.alarmOn = false;
            TT.removeFromList("TaskVent");
            UIManager.AdjustScore(50);
            timer.timeleft += 9;

        }
    }
}
