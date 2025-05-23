using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    public class ItemsContainer : MonoBehaviour, IItemContainer<Item>
    {
        [SerializeField] private int _capacity;
        [SerializeField] private List<Item> _items;

        private void OnValidate()
        {
            if (_items == null)
                return;
            
            if (_items.Count > _capacity)
                _items.RemoveRange(_capacity, _items.Count - _capacity);
        }

        public event Action OnCollectionChanged;
        
        public IReadOnlyList<Item> Items => _items;

        public bool TryAdd(Item item)
        {
            if (_items.Count >= _capacity)
                return false;
            
            _items.Add(item);
            OnCollectionChanged?.Invoke();
            return true;
        }
        public bool TryRemove(Item item)
        {
            if (!_items.Contains(item))
                return false;

            _items.Remove(item);
            OnCollectionChanged?.Invoke();
            return true;
        }
    }
}