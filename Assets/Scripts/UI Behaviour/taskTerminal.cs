using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class taskTerminal : MonoBehaviour
{
    public ventBehaviour[] ventBehaviour;
    public bool ventTaskActive;
    public bool lightTaskActive;
    public bool radioTaskActive;
    public bool WaveAlienTaskActive;
    public int ventNumber;
    
    private TextMeshProUGUI currentTask;
    private FlashingLights lightFlash;

    private int chosenTask;

    [Header("Time between each task:")]
    [SerializeField] private float time = 15f; //give 10 seconds between each task  
    [SerializeField] private GameObject listTasks; 
    [SerializeField] private Transform listParent;
    private float timer = 0f;
    private float itemHeight = 80f; // Spacing between items

    private void Start()
    {
        lightFlash = GameObject.Find("Directional Light").GetComponent<FlashingLights>();
        currentTask = GameObject.Find("Current Task").GetComponent<TextMeshProUGUI>();

        listParent = GameObject.Find("Main Task Panel").transform;
        listTasks = GameObject.Find("ListTasks");
    }
    private void Update()
    {

        timer += Time.deltaTime; // Accumulate elapsed time

        if (timer >= 2f)
        {
            selectTask();
            timer = 0f; // Reset the timer
        }


        ReorganizeList();


        //     selectTask(); //always make sure there is a task

    }


    void addToList(string task, string tag)
    {
        GameObject newTask = Instantiate(listTasks, listParent);
        TextMeshProUGUI textComponent = newTask.GetComponent<TextMeshProUGUI>();
        newTask.tag = tag;
        textComponent.text = task;

        RectTransform rectTransform = newTask.GetComponent<RectTransform>();
        int itemCount = listParent.childCount;
        rectTransform.anchoredPosition = new Vector2(0, -itemHeight * (itemCount - 1));
    }

    public void removeFromList(string tag) 
    {
        GameObject taskToRemove = GameObject.FindWithTag(tag);
        Destroy(taskToRemove);
        
            }

    private void ReorganizeList()
    {
        // Loop through all children and adjust their positions
        for (int i = 0; i < listParent.childCount; i++)
        {
            RectTransform rectTransform = listParent.GetChild(i).GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -itemHeight * i);
        }
    }




    public void selectTask()
    {
         // if (!ventTaskActive && !lightTaskActive && !radioTaskActive && !WaveAlienTaskActive ) 
          //{
 
            chosenTask = Random.Range(0, 4);

            switch (chosenTask)
            {
                case 0:
                    if (!ventTaskActive) //vent task
                    {
                        ventNumber = Random.Range(0, 3);
                        ventBehaviour[ventNumber].igniteVent();


                        ventTaskActive = true;
                        // currentTask.text = "Extinguish Vents";
                        addToList("Extinguish Vent", "TaskVent");
                        print("Task Chosen: Vent Ignition" + ventNumber);
                    }
                    break;

                case 1:
                    if (!lightTaskActive)
                    {
                        lightFlash.alarmOn = true;
                        lightTaskActive = true;
                        //currentTask.text = "Fix Lights";
                        addToList("Fix Lights", "TaskLights");

                        print("Task Chosen: Fix Lights");
                    }
                    break;
                case 2:
                    if (!radioTaskActive)
                    {
                        radioTaskActive = true;

                      //  currentTask.text = "Press Radio";
                        addToList("Press Radio", "TaskRadio");
                        print("Task radio active");
 
                    }

                    break;
                case 3: 
                    if(!WaveAlienTaskActive)
                    {
                        WaveAlienTaskActive = true;
                   // currentTask.text = "Wave to Alien";
                        addToList("Wave to Alien", "TaskAlien");
                        print("Task: Wave");
                    }
                    break;

      //      }
       }
    }

    /*
    public void eraseTaskList()
    {
       // currentTask.text = string.Empty; //makes task text empty
    }
    */
}
