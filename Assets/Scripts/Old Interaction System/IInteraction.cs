using UnityEngine;
using UnityEngine.Events;

namespace StarterAssets.Interactions
{
  public interface IInteraction
    {
        public UnityEvent onInteract { get; protected set; }
        public void Interact();

    }

}