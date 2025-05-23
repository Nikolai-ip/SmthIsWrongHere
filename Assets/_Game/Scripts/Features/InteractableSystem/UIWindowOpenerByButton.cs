using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class UIWindowOpenerByButton : UIWindowOpener
    {
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
    }
}