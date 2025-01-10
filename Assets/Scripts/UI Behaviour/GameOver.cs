using UnityEngine;
using UnityEngine.AI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private MainUIManager score;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject alien;
    [SerializeField] private GameObject TaskTerminal;
    [SerializeField] private GameObject UI;
    public void displayGameOverMenu()
    {
        gameOverMenu.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        score.overallScore();
        freezeGameplay();

    }

    void freezeGameplay()
    {
        player.GetComponent<InputManager>().enabled = false;
        alien.GetComponent<AlienMovement>().enabled = false;
        alien.GetComponent<Animator>().enabled = false;
        alien.GetComponent<NavMeshAgent>().enabled = false;
        alien.GetComponent<Interactable>().enabled = false;
        UI.SetActive(false);
        TaskTerminal.GetComponent<taskTerminal>().enabled = false;

    }
}
