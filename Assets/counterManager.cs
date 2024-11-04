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
}
