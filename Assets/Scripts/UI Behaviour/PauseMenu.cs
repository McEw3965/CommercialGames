using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject crosshair;
    public GameObject UIElements;
    public GameObject settings;
    public  bool isPaused;
    [SerializeField] private GameObject gamepadMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
        isPaused = false;
    }
      

    public void PauseGame()
    {
        if(isPaused)
        {
            ResumeGame();
        } else
        {
            Debug.Log("PAUSED!");
            pauseMenu.SetActive(true);
            UIElements.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crosshair.SetActive(false);
        }

    }

    public void ResumeGame()
    {
        Debug.Log("RESUME!");
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        gamepadMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        crosshair.SetActive(true);
        UIElements.SetActive(true);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }


    public void gamepadmenusettings()
    {
        gamepadMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void keyboardmenusettings()
    {
        gamepadMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void SettingsMenu()
    {
        settings.SetActive(true);
    }
    public void BackToPauseMenu()
    {
        settings.SetActive(false);
        gamepadMenu.SetActive(false);

    }
    public void BackToMenu()
    {
        Debug.Log("BACK TO MENU!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

        #if UNITY_EDITOR
           
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
