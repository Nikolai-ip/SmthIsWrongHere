using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpenerByInteract : UIWindowOpener, IInteractable
    {
        public void Interact(GameObject @this) => Open();
    }
}