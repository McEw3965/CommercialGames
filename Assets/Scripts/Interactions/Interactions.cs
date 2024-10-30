
using StarterAssets.Interactions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    private PlayerInput playerInput;
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.onActionTriggered += DoInteract;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= DoInteract;
    }


    private void DoInteract(InputAction.CallbackContext value)
    {
        if (!Physics.Raycast(_transform.position + (Vector3.up * 0.3f) + (_transform.forward * 0.2f), _transform.forward, out var hit, 1.5f, interactableLayer)) return;


        if (!hit.transform.TryGetComponent(out InteractableObject interactable)) return; //check if we can get component returns true or false
        ///if true it will output interactable
        ///
        interactable.Interact();
        Debug.Log(value.action.name);

    }
}
