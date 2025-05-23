using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Core.InventorySystem
{
    public class ItemsContainerController : MonoBehaviour
    {
        [FormerlySerializedAs("_containerUI")] [SerializeField] private SlotsContainerUI slotsContainerUI;

        [SerializeField] private ItemsContainer _from;
        [SerializeField] private ItemsContainer _to;

        private void Awake() => RefreshUI();
        private void OnEnable() => _from.OnCollectionChanged += RefreshUI;
        private void OnDestroy() => _from.OnCollectionChanged -= RefreshUI;

        private void RefreshUI()
        {
            slotsContainerUI.Refresh(_from.Items);

            foreach (SlotUI slotUI in slotsContainerUI.Slots) 
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