using _Game.Scripts.Core.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpener : MonoBehaviour, IInteractable
    {
        [SerializeField] private UIWindow _uiWindow;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            if (_button == null)
                return;
            
            _button.onClick.AddListener(Open);
        }
        private void OnDisable()
        {
            if (_button == null)
                return;
            
            _button.onClick.RemoveListener(Open);
        }
        
        public void Interact(GameObject @this) => Open();
        public void Open() => _uiWindow.Show();
    }
    
    
}