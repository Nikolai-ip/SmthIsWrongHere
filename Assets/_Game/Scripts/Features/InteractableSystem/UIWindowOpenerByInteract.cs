using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpenerByInteract : UIWindowOpener
    {
        public override void Interact(GameObject @this) => Open();
    }
}