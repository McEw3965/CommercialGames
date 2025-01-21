using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject gamepadMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        settingsMenu.SetActive(true);
    }


    public void gamepadmenusettings()
    {
        gamepadMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void keyboardmenusettings()
    {
        gamepadMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void ResetGame()
    {
        PlayGame();
    }


    public void QuitGame()
    {
        Application.Quit();


        #if UNITY_EDITOR
                // Stop playing the game in the Editor
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
