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
        generatePassword();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generatePassword()
    {
        int randNum = Random.Range(100, 1000);
        correctPass = randNum.ToString();
        Debug.Log("Current Code: " + correctPass);
    }

    public void checkCode()
    {
        if (tempPass.Length == 3)
        {
            if (tempPass == correctPass)
            {
                Debug.Log("Correct Password!");
            }
            else if (tempPass != correctPass)
            {
                Debug.Log("Incorrect Password!");
            }
        }

        tempPass = "";
        generatePassword();
    }
}
