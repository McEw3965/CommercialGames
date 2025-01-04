using System;
using UnityEngine;

public class CaptainTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] triggerWalls;
    [SerializeField] private GameObject[] captains;

    private void Start()
    {
        for (int i = 0; i < captains.Length; i++)
        {
            captains[i].gameObject.SetActive(false); //makes all captains false
        }
    }


    private void Update()
    {
        for (int i = 0; i < triggerWalls.Length; i++)
        {
            if (triggerWalls[i].GetComponent<WallTrigger>().isTriggered) //if triggerwall has been triggered....
            {
                captains[i].gameObject.SetActive(true); //set that captain to true
            }
            else
            {
                captains[i].gameObject.SetActive(false);
            }  
            }
        }
    }
