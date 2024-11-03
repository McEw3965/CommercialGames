using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventBehaviour : MonoBehaviour
{
    public GameObject fireEffects;

    private bool isOnFire = false;
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
        isOnFire = true;
        fireEffects.SetActive(true);
    }

    public void repairVent()
    {
        isOnFire = false;
        fireEffects.SetActive(false);
    }
}
