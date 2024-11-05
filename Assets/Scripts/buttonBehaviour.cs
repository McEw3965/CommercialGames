using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehaviour : MonoBehaviour
{
    public counterManager CM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonPressed()
    {
        if (this.gameObject.name == "Up" && CM.currentLevel + 0.5f <= 100)
        {
            CM.currentLevel += 0.5f;
        } else if(this.gameObject.name == "Down")
        {
            CM.currentLevel -= 0.5f;
        }
    }
}
