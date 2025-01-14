using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public StartGameScript start;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        //doesnt exist yet
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
