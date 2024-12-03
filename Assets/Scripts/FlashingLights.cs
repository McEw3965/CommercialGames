using System.Collections;
using TMPro;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public Light lights; //the light its changing
    public float BlinkingTime; //time per blink
    public AudioSource alarm; //alarm audio
    public TextMeshProUGUI Task; //alarm task
    public Animator animator;
    public PauseMenu pauseMenu;
    float timer = 1.5f;
    public bool alarmOn = false;
    
    private taskTerminal TT;
    MainUIManager UIManager;

    private void Start()
    {
        UIManager = FindAnyObjectByType<MainUIManager>();
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
        lights.gameObject.SetActive(false);

    }


    void Update()
    {

        timer += Time.deltaTime;

        if (!pauseMenu.isPaused) {

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
        } else
        {
            alarm.Stop();
        }
    }

    public void StopAlarm()
    {
        if (TT.alarmTaskActive)
        {
            Debug.Log("Stopping Alarm");
            alarm.Stop();
            alarmOn = false;
            if (TT.alarmTaskActive)
            {
                TT.alarmTaskActive = false;
                TT.removeFromList("TaskAlarm");
            }

            bool lever = animator.GetBool("leverDown");

            print("AT 1; " + lever);
            animator.SetBool("leverDown", !lever);
            print("AT 2; " + lever);
            animator.SetBool("leverDown", !lever);
            print("AT 3; " + lever);
            UIManager.AdjustScore(20);
        }

    }



    IEnumerator Blink()
    {
        Debug.Log("Blink");
        
        lights.gameObject.SetActive(true);
        yield return new WaitForSeconds(.4f); //Wait 0.4 seconds

        lights.gameObject.SetActive(false);

    }

}
