using _Game.Scripts.Core.InventorySystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class PickableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemsContainer _itemContainer;

        public void Interact(GameObject @this)
        {
            var inventory = @this.GetComponentInChildren<ItemsContainer>();
            if (!ItemsTransfer.TransferItem(_itemContainer.Items[0], _itemContainer, inventory))
                return;
            
            Destroy(gameObject);
        }
    }
}