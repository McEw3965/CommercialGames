using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingLights : MonoBehaviour
{
    public Light lights; //the light its changing
    public float BlinkingTime; //time per blink
    public AudioSource alarm; //alarm audio
    public RawImage WarningSign; //warning sign

    float timer;
    bool alarmOn = false;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > BlinkingTime)
        {
            StartCoroutine("Blink"); //start blinking
            if (!alarmOn)
            {
                alarm.Play();  //play the audio
                alarmOn = true;
            }
         
            timer = 0;
        }

    }

     void StopAlarm()
    {
        alarm.Stop();
        alarmOn = false;
    }
    IEnumerator Blink()
    {

        lights.color = Color.yellow; //changes light to yellow color
        WarningSign.enabled = true; //display image
        yield return new WaitForSeconds(.4f); //wait 0.4 seconds
        lights.color = Color.white; //change color to white
        WarningSign.enabled = false; //remove image

    }

}
