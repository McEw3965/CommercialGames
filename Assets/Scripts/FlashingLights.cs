using System.Collections;
using TMPro;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public GameObject flashingLights;

    [SerializeField] private GameObject directionalLighting;
  
    public float BlinkingTime; 
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
        flashingLights.SetActive(false);
        alarmOn = false;
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (!pauseMenu.isPaused) {

            if (alarmOn) 
            {
               
                if (timer > BlinkingTime)
                {
                    StartCoroutine(Blink());
                    timer = 0;
                }
            }
        } 
    }

    public void StopAlarm()
    {
        if (TT.alarmTaskActive)
        {
            Debug.Log("Stopping Alarm");

            TT.speakers[TT.ventNumber].Stop(); //turns off alarm

          alarmOn = false;
          
             TT.alarmTaskActive = false;
             TT.removeFromList("TaskAlarm");
            

            bool lever = animator.GetBool("leverDown");

          
            animator.SetBool("leverDown", !lever);

            UIManager.AdjustScore(20);
        }

    }



    IEnumerator Blink()
    {
        Debug.Log("Blink");

        flashingLights.SetActive(true);
        directionalLighting.gameObject.SetActive(false);
        yield return new WaitForSeconds(.8f);

        flashingLights.SetActive(false);
        directionalLighting.gameObject.SetActive(true);

    }

}
