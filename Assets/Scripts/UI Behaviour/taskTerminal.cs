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
    public CutSceneEnter cutscene;
    public bool ventTaskActive;
    public bool lightTaskActive;
    public bool radioTaskActive;
    public bool WaveAlienTaskActive;
    public int ventNumber;
    
    private FlashingLights lightFlash;

    private int chosenTask;

    [Header("Time between each task:")]
    [SerializeField] private float time = 5f; 
    [SerializeField] private GameObject listTasks; 
    [SerializeField] private Transform listParent;
    private float timer = 0f;
    [Header("Space between each task in UI")]
    [SerializeField] private float itemHeight = 100f; // Spacing between items

    private void Start()
    {
        lightFlash = GameObject.Find("Directional Light").GetComponent<FlashingLights>();
        listParent = GameObject.Find("Main Task Panel").transform;
        listTasks = GameObject.Find("ListTasks");
    }
    private void Update()
    {
       
            timer += Time.deltaTime;

            if (timer >= time)
            {
                selectTask();
                timer = 0f;
            }


            ReorganizeList();
        
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

        rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y); // Set left offset to 0
        rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y); // Right offset remains the same

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
       
 
            chosenTask = Random.Range(0, 4);

            switch (chosenTask)
            {
                case 0:
                    if (!ventTaskActive) 
                    {
                        ventNumber = Random.Range(0, 3);
                        ventBehaviour[ventNumber].igniteVent();


                        ventTaskActive = true;
                        addToList("Extinguish Vent", "TaskVent");
                        print("Task Chosen: Vent Ignition" + ventNumber);
                    }
                    break;

                case 1:
                    if (!lightTaskActive)
                    {
                        lightFlash.alarmOn = true;
                        lightTaskActive = true;
                        addToList("Fix Lights", "TaskLights");

                        print("Task Chosen: Fix Lights");
                    }
                    break;
                case 2:
                    if (!radioTaskActive)
                    {
                        radioTaskActive = true;

                        addToList("Press Radio", "TaskRadio");
                        print("Task radio active");
 
                    }

                    break;
                case 3: 
                    if(!WaveAlienTaskActive)
                    {
                        WaveAlienTaskActive = true;
                        addToList("Wave to Alien", "TaskAlien");
                        print("Task: Wave");
                    }
                    break;
       }
    }

}
