using System;
using System.Collections.Generic;

namespace _Game.Scripts.Core.InventorySystem
{
    public interface IItemContainer<T>
    {
        public event Action OnCollectionChanged;
        IReadOnlyList<T> Items { get; }
        bool TryAdd(T item);
        bool TryRemove(T item);
    }
}