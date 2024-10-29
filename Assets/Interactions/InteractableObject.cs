using UnityEngine;
using UnityEngine.Events;
namespace StarterAssets.Interactions
{
    public class InteractableObject : MonoBehaviour, IInteraction
    {
        [SerializeField] private UnityEvent onInteract;

        UnityEvent IInteraction.onInteract
        {
            get => onInteract;
            set=> onInteract = value;
        }
        public void Interact() => onInteract.Invoke();
    }


}