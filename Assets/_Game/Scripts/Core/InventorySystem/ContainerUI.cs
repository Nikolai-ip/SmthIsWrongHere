using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    public class ContainerUI : UIWindow
    {
        [SerializeField] private SlotUI _slotUIPrefab;
        [SerializeField] private Transform _parentTransform;
                
        [SerializeField] private List<SlotUI> _slots;

        public IReadOnlyList<SlotUI> Slots => _slots;
        
        public void Refresh(IReadOnlyList<Item> items)
        {
            _slots.ForEach(s => Destroy(s.gameObject));
            _slots.Clear();
            
            foreach (Item item in items)
            {
                SlotUI slotUI = Instantiate(_slotUIPrefab, _parentTransform);
                slotUI.Construct(item);

                _slots.Add(slotUI);
            }
        }
    }
}