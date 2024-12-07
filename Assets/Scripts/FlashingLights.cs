using System.Collections;
using TMPro;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public Light flashingLight;

    [SerializeField] private GameObject directionalLighting;
    
    public float BlinkingTime; 
    public AudioSource alarm; 
    public Animator animator;
    public PauseMenu pauseMenu;


    float timer = 1.5f;

    public bool alarmOn;
    
    private taskTerminal TT;
    MainUIManager UIManager;

    private void Start()
    {
        UIManager = FindAnyObjectByType<MainUIManager>();
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
        flashingLight.gameObject.SetActive(false);
        alarmOn = false;
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (!pauseMenu.isPaused) {

            if (alarmOn) 
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
          
             TT.alarmTaskActive = false;
             TT.removeFromList("TaskAlarm");
            

            bool lever = animator.GetBool("leverDown");

            /*
            print("AT 1; " + lever);
            animator.SetBool("leverDown", !lever);
            print("AT 2; " + lever);
            animator.SetBool("leverDown", !lever);
            print("AT 3; " + lever);*/
            animator.SetBool("leverDown", !lever);

            UIManager.AdjustScore(20);
        }

    }



    IEnumerator Blink()
    {
        Debug.Log("Blink");

        flashingLight.gameObject.SetActive(true);
        directionalLighting.gameObject.SetActive(false);
        yield return new WaitForSeconds(.4f); //Wait 0.4 seconds

        flashingLight.gameObject.SetActive(false);
        directionalLighting.gameObject.SetActive(true);

    }

}
