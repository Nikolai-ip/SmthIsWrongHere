using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
    public class Item : ScriptableObject
    {
        public Sprite Icon;
        public ItemType Type;
        
        public enum ItemType
        {
            Apple = 0,
            Cactus = 1,
            Knife = 2,
        }
    }
}