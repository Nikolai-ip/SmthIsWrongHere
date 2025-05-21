using _Game.Scripts.Core.InventorySystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpener : MonoBehaviour, IInteractable
    {
        [SerializeField] private UIWindow _uiWindow;

        public void Interact(GameObject @this) => _uiWindow.Show();
    }
}