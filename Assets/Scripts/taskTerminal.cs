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
    public bool radioTaskActive;

    public TextMeshProUGUI currentTask;
    public RadioController rc;
  

    public void selectTask()
    {
        if (!ventTaskActive && !lightTaskActive && !radioTaskActive)
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
                case 2:
                    if (!radioTaskActive)
                    {
                        radioTaskActive = true;
                       

                        currentTask.text = "Press Radio";
                        print("Task radio active");

                        /*
                        if (!rc.isRadioOn)
                        {
                            currentTask.text = "Turn on Radio";
                        }

                        else if (rc.isRadioOn && rc.trackNum < rc.RadioTracks.Length - 1)
                        {
                            currentTask.text = "Change Track on Radio";

                        }
                        else
                        {
                            currentTask.text = "Turn Radio Off";
                        }
                        print("Task Chosen: Play Radio");
                    }*/
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
