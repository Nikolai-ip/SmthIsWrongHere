using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    public abstract class UIWindow : MonoBehaviour
    {
        public void Show() => this.gameObject.SetActive(true);
        public void Hide() => this.gameObject.SetActive(false);
    }
}