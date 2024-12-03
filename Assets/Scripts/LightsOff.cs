using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour
{
    public taskTerminal TT;
    public GameObject lights;
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
            lights.SetActive(false);
        }
    }

    public void turnOnLights()
    {
        TT.lightTaskActive = false;
        lights.SetActive(true);
    }
}
