using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class counterManager : MonoBehaviour
{
    public float currentLevel = 90.34f;
    private float timer = 0.25f;

    public Text counter;
    public GameObject taskMenu;
    public Light mainLight;
    public MainUIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        System.Math.Round(currentLevel, 2);
        counter.text = currentLevel.ToString();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0.25f;
            currentLevel -= 0.1f;
        }

        oxygenLevelEvents();


    }

    public void showMenu()
    {
        taskMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void hideMenu()
    {
        taskMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void oxygenLevelEvents()
    {
        if (currentLevel <= 30)
        {
            mainLight.color = Color.blue;
            UIManager.AdjustScore(-25);
        }
        else if (currentLevel > 30)
        {
            mainLight.color = Color.white;

        }
        else if (currentLevel <= 0)
        {
            Application.Quit();
        }
    }
}
