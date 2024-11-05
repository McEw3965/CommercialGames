using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventBehaviour : MonoBehaviour
{
    public GameObject fireEffects;

    private bool isOnFire = false;
    public taskTerminal TT;
    public AudioSource alarm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void igniteVent()
    {
        if (!isOnFire)
        {
            isOnFire = true;
            fireEffects.SetActive(true);
            alarm.Play();
            print("Vent Ignited");
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
        }
    }
}
