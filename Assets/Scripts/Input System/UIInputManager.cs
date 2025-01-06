using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.UIActions onUI;
    public StartDialogue dialogue;


    private void Awake()
    {
        playerInput = new PlayerInput();
        onUI = playerInput.UI;

        onUI.Click.performed += ctx => dialogue.displayText();
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
