using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeManager : MonoBehaviour
{
    private string correctPass;

    public string tempPass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generatePassword()
    {
        int randNum = Random.Range(100, 1000);
        correctPass = randNum.ToString();
    }

    private void checkCode()
    {
        if (tempPass == correctPass)
        {

        } else if(tempPass != correctPass)
        {

        }
    }
}
