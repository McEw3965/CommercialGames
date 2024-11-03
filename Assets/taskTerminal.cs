using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskTerminal : MonoBehaviour
{
    private int chosenTask;
    public ventBehaviour ventBehaviour;
  
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
                ventBehaviour.igniteVent();
                break;
        }
    }
}
