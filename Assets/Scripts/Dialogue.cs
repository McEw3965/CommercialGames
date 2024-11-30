using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//https://www.youtube.com/watch?v=8oTYabhj248&ab_channel=BMo
public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    public void displayText()
    {
        NextLine(); //next line 
    }

    void StartDialogue()
    {
        index = 0;
        DisplayLine(); //first line displayed

    }

    void DisplayLine()
    {
        textComponent.text = lines[index]; 
    }

    void NextLine()
    {
        if (index < lines.Length - 1) //if index is less than length of array
        {
            index++; //increase index by one for next sentence
            DisplayLine(); // Display the next line
        }
        else
        {
            Debug.Log("End of dialogue.");
            gameObject.SetActive(false); // Disable the dialogue object when finished
        }
    }
}
