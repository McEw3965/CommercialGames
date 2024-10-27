using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public Light lights;
    public float BlinkingTime;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > BlinkingTime)
        {
            StartCoroutine("Blink");
            timer = 0;
           
        }
    }

    IEnumerator Blink()
    {
        lights.enabled = false;
        yield return new WaitForSeconds(.4f);
        lights.enabled = true;

    }

}
