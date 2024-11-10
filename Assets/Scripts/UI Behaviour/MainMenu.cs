using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void Setting()
    {
        //doesnt exist yet
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
