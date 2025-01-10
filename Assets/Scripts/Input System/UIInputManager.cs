using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.UIActions onUI;
    public StartDialogue dialogue;
    public PauseMenu pauseMenu;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onUI = playerInput.UI;

        onUI.Click.performed += ctx => dialogue.displayText();
        onUI.Escape.performed += ctx => pauseMenu.PauseGame();
    }


    private void OnEnable()
    {
        onUI.Enable();
    }
    private void OnDisable()
    {
   
        onUI.Disable();

    }
}
