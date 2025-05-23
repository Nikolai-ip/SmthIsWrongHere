using _Game.Scripts.Core.InventorySystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpener : MonoBehaviour
    {
        [SerializeField] private UIWindow _uiWindow;
        public void Open() => _uiWindow.Show();
    }
}