using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Core.InventorySystem
{
    public class SlotUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        public Button Button;
        
        public Item CurrentItem { get; private set; }
        
        public void Construct(Item item)
        {
            CurrentItem = item;
            _icon.sprite = CurrentItem.Icon;
        }
    }
}