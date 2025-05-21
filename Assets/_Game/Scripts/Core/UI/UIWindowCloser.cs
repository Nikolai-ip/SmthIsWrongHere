using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    public class UIWindowCloser : MonoBehaviour
    {
        [SerializeField] private UIWindow _uiWindow;

        private void Update()
        {
            if (!this.gameObject.activeInHierarchy)
                return;
            
            if (Input.GetKeyDown(KeyCode.Escape))
                _uiWindow.Hide();
        }
    }
}