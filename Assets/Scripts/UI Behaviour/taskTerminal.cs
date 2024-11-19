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
    public bool WaveAlienTaskActive;

    public TextMeshProUGUI currentTask;
    public RadioController rc;
  

    public void selectTask()
    {
          if (!ventTaskActive && !lightTaskActive && !radioTaskActive && !WaveAlienTaskActive)
          {
        /* quick debug
        ventTaskActive = false;
        lightTaskActive = false;
        radioTaskActive = false;
        WaveAlienTaskActive = false;
        eraseTaskList();*/

            chosenTask = Random.Range(0, 1);

            switch (chosenTask)
            {
                case 0:
                    if (!ventTaskActive) //vent task
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
                case 3: 
                    if(!WaveAlienTaskActive)
                    {
                        WaveAlienTaskActive = true;
                    currentTask.text = "Wave to Alien";

                    print("Task: Wave");
                    }
                    break;

            }
            
       }
    }

    public void eraseTaskList()
    {
        currentTask.text = string.Empty; //makes task text empty
    }
}
