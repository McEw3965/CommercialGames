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
            mainLight.color = Color.white;

        }
    }
}
