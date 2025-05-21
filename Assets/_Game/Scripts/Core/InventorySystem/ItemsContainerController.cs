using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    public class ItemsContainerController : MonoBehaviour
    {
        [SerializeField] private ContainerUI _containerUI;

        [SerializeField] private ItemsContainer _from;
        [SerializeField] private ItemsContainer _to;

        private void Awake() => RefreshUI();
        private void OnEnable() => _from.OnCollectionChanged += RefreshUI;
        private void OnDestroy() => _from.OnCollectionChanged -= RefreshUI;

        private void RefreshUI()
        {
            _containerUI.Refresh(_from.Items);

            foreach (SlotUI slotUI in _containerUI.Slots) 
                slotUI.Button.onClick.AddListener(() => ItemsTransfer.TransferItem(slotUI.CurrentItem, _from, _to));
        }
    }

    public class ItemsTransfer
    {
        public static bool TransferItem(Item item, ItemsContainer from, ItemsContainer to)
        {
            if (!to.TryAdd(item))
                return false;
            
            if (!from.TryRemove(item))
                return false;

            return true;
        }
    }
}