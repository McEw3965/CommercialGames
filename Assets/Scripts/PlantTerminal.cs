using UnityEngine;

public class PlantTerminal : MonoBehaviour
{
    [SerializeField] private GameObject plantDataMenu;
    [SerializeField] private GameObject WaterDrops;

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
       WaterDrops.SetActive(false);
       
    }
}
