using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class codeManager : MonoBehaviour
{
    private string correctPass;

    public string tempPass;

    public TextMeshPro codeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        generatePassword();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempPass.Length > 3)
        {
            tempPass = "";
            Debug.Log("Attempt Reset as password was too long");
        }
    }

    private void generatePassword()
    {
        int randNum = Random.Range(100, 1000);
        correctPass = randNum.ToString();
        codeDisplay.text = correctPass;
        Debug.Log("Current Code: " + correctPass);
    }

    public void checkCode()
    {
        Debug.Log(tempPass.Length);
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
