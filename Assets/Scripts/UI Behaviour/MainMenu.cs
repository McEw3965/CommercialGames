using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
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
