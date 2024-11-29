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
        if (index >= lines.Length)
        {
            Debug.LogWarning("No more lines to display.");
            return; // Exit if we are beyond the last line
        }

        if (textComponent.text == lines[index]) // If the current line is fully displayed
        {
            NextLine(); // Proceed to the next line
        }
        else
        {
            Debug.Log("Skipping to current line: " + lines[index]);
            textComponent.text = lines[index]; // Ensure the line is displayed immediately
        }
    }

    void StartDialogue()
    {
        index = 0;
        DisplayLine(); // Display the first line
    }

    void DisplayLine()
    {
        Debug.Log("Displaying line: " + lines[index]);
        textComponent.text = lines[index]; // Set the current line directly
    }

    void NextLine()
    {
        if (index < lines.Length - 1) // Check if there are more lines
        {
            index++;
            DisplayLine(); // Display the next line
        }
        else
        {
            Debug.Log("End of dialogue.");
            gameObject.SetActive(false); // Disable the dialogue object when finished
        }
    }
}
