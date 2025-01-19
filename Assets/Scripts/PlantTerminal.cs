using Unity.VisualScripting;
using UnityEngine;

public class PlantTerminal : MonoBehaviour
{
   
    [SerializeField] private GameObject plantDataMenu;
    [SerializeField] private GameObject WaterDrops;
    [SerializeField] private taskTerminal TT;
    [SerializeField] private Timer timer;
    [SerializeField] private MainUIManager UIManager;



    public void enterPlantMenu()
    {
        plantDataMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void exitMenu()
    {
        plantDataMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void fixPlants()
    {
        if (TT.plantTaskActive)
        {
            //user fixes the plant then they need points
            WaterDrops.SetActive(false);
            TT.plantTaskActive = false;
            TT.removeFromList("TaskPlants");
            UIManager.AdjustScore(10);
            timer.timeleft += 5;
        }
            
       
    }

    private void Update()
    {
        if (TT.plantTaskActive)
        {
            WaterDrops.SetActive(true);
        }
    }







}
