using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TextMeshPro text;
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

            text.color = Color.red;
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
            text.color = Color.white;
        }
    }
}
