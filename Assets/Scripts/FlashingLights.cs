using System.Collections;
using TMPro;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public Light lights; //the light its changing
    public float BlinkingTime; //time per blink
    public AudioSource alarm; //alarm audio
    public TextMeshProUGUI Task; //alarm task

    float timer = 1.5f;
    public bool alarmOn = false;
    bool alarmHasBeenTurnedOff = false;

    public taskTerminal TT;

    void Update()
    {
        timer += Time.deltaTime;

        /*if (!alarmHasBeenTurnedOff)
        {
            if (!alarmOn && timer > BlinkingTime)
            {
                StartCoroutine(Blink());  // Start the blinking coroutine
                alarm.Play();             // Play the audio alarm
                alarmOn = true;           // Set alarmOn to true to avoid repeating this block
                timer = 0;                // Reset timer
            }
        } */

        if (alarmOn) //Lights blink if alarm is on
        {
            if (!alarm.isPlaying)
            {
                alarm.Play();
            }

            if (timer > BlinkingTime)
            {
                StartCoroutine(Blink());
                timer = 0;
            }

        }
    }

    public void StopAlarm()
    {
        Debug.Log("Stopping Alarm");
        alarm.Stop();
        removeTaskFromList();
        alarmOn = false;
        alarmHasBeenTurnedOff = true;
        TT.lightTaskActive = false;
        TT.eraseTaskList();
    }



    void removeTaskFromList()
    {
        Task.fontStyle = FontStyles.Strikethrough;
    }
    IEnumerator Blink()
    {
        Debug.Log("Blink");
        lights.color = Color.red; //changes light to yellow color
        yield return new WaitForSeconds(.4f); //Wait 0.4 seconds
        lights.color = Color.white; //change color to white

    }

}
