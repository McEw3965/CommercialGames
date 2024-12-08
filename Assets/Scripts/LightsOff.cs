using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour
{
    public taskTerminal TT;
    public GameObject lights;
    public Animator lightSwitchAnimation;
    // Start is called before the first frame update
    void Start()
    {
        lights.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(TT.lightTaskActive)
        {
            turnOffLights();
        }
    }

    public void turnOnLights()
    {
        TT.lightTaskActive = false;
        lights.SetActive(true);
        lightSwitchAnimation.SetBool("TopPressed", true);

    }

    public void turnOffLights()
    {
        lights.SetActive(false);
        lightSwitchAnimation.SetBool("BottomPressed", true);

    }
}
