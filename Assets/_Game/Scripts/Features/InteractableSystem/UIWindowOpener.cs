using _Game.Scripts.Core.InventorySystem;
using _Game.Scripts.Features.InteractedObjects;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpener : InteractedMono
    {
        [SerializeField] private UIWindow _uiWindow;
        protected void Open() => _uiWindow.Show();
    }
}