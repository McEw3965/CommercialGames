using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskTerminal : MonoBehaviour
{
    private int chosenTask;
    public ventBehaviour[] ventBehaviour;

    public bool ventTaskActive;
  
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
        chosenTask = Random.Range(0, 1);

        switch (chosenTask)
        {
            case 0:
                if (!ventTaskActive)
                {
                    ventBehaviour[Random.Range(0, 3)].igniteVent();
                    ventTaskActive = true;
                    print("Task Chosen: Vent Ignition");
                } 
                break;
        }
    }
}
