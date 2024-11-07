using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class taskTerminal : MonoBehaviour
{
    private int chosenTask;
    public ventBehaviour[] ventBehaviour;
    public FlashingLights lightFlash;

    public bool ventTaskActive;
    public bool lightTaskActive;

    public TextMeshProUGUI currentTask;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void selectTask()
    {
        if (!ventTaskActive && !lightTaskActive)
        {
            chosenTask = Random.Range(0, 2);

            switch (chosenTask)
            {
                case 0:
                    if (!ventTaskActive)
                    {
                        ventBehaviour[Random.Range(0, 3)].igniteVent();
                        ventTaskActive = true;
                        currentTask.text = "Extinguish Vents";
                        print("Task Chosen: Vent Ignition");
                    }
                    break;

                case 1:
                    if (!lightTaskActive)
                    {
                        lightFlash.alarmOn = true;
                        lightTaskActive = true;
                        currentTask.text = "Fix Lights";
                        print("Task Chosen: Fix Lights");
                    }
                    break;
            }
        }
    }

    public void eraseTaskList()
    {
        currentTask.text = string.Empty;
    }
}
