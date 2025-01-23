using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour
{

    [SerializeField] private Timer timer;
    public taskTerminal TT;
    public GameObject lights;

    void Start()
    {
        lights.SetActive(true);
    }

    void Update()
    {
        if(TT.lightTaskActive)
        {
            turnOffLights();
        }
    }

    public void turnOnLights()
    {

        if (TT.lightTaskActive) {

        timer.timeleft += 5;

            TT.lightTaskActive = false;
            lights.SetActive(true);
            //lightSwitchAnimation.SetBool("TopPressed", true);
            TT.removeFromList("TaskLights");
        }
    }

    public void turnOffLights()
    {
        lights.SetActive(false);
      //  lightSwitchAnimation.SetBool("BottomPressed", true);
    }
}
