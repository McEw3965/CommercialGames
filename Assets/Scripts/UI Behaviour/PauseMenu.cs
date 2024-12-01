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
    public  bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                PauseGame();
            } else
            {
                ResumeGame();
            }
          
        }
    }

    public void PauseGame()
    {
        Debug.Log("PAUSED!");
        pauseMenu.SetActive(true);
        UIElements.SetActive(false );
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
    }

    public void ResumeGame()
    {
        Debug.Log("RESUME!");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        crosshair.SetActive(true);
        UIElements.SetActive(true);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


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
                // Stop playing the game in the Editor
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
