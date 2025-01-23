using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//reference to dialogue system
//https://www.youtube.com/watch?v=8oTYabhj248&ab_channel=BMo
public class StartDialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    private int index;
    public bool dialogueon;

    public AudioSource[] sound;




    void randomSoundPicker()
    {
        int num = Random.Range(0, sound.Length);

        switch (num)
        {

            case 0:
                sound[0].Play(); break;
            case 1:
                sound[1].Play(); break;
            case 2:
                sound[2].Play(); break;
            case 3:
                sound[3].Play(); break;

        }
    }

    void Start()
    {
      

        textComponent.text = string.Empty;

        StartDialogues();
    }

  
    public void displayText()
    {
        randomSoundPicker();
        NextLine(); //next line 
    }

    public void StartDialogues()
    {
        index = 0;
        dialogueon = true;
        DisplayLine(); //first line displayed
    


    }

    void DisplayLine()
    {
        
        textComponent.text = lines[index];
        dialogueon = true;
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
            dialogueon = false;
            gameObject.SetActive(false); // Disable the dialogue object when finished


            for (int i = 0; i < sound.Length; i++)
            {

                sound[i].Stop();
            }
           
        }
    }
}
