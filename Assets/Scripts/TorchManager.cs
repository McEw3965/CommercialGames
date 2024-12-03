using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
   public GameObject torch;

    private void Start()
    {
        torch.SetActive(false);
    }
    public void ToggleTorch()
    {

        if (torch == null)
        {
            Debug.LogError("Map is null! Ensure it is assigned in the Inspector or code.");
            return;
        }

        if (torch.activeSelf)
        {
            torch.SetActive(false); // If currently active, deactivate it
        }
        else
        {
            torch.SetActive(true); // If currently inactive, activate it
        }
    
    }

}
