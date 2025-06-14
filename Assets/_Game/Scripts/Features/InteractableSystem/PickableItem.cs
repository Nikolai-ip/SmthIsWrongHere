using _Game.Scripts.Core.InventorySystem;
using _Game.Scripts.Features.InteractedObjects;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class PickableItem : InteractedMono
    {
        [SerializeField] private ItemsContainer _itemContainer;

        public override void Interact(GameObject @this)
        {
            base.Interact(@this);
            var inventory = @this.GetComponentInChildren<ItemsContainer>();
            if (!ItemsTransfer.TransferItem(_itemContainer.Items[0], _itemContainer, inventory))
                return;
            Destroy(gameObject);
        }
    }
}