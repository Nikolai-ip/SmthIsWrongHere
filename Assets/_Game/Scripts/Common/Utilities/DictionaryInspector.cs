using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Scripts.Common.Utilities
{
    [Serializable]
    class DictionaryInspector<TKey, TValue>
    {
        [SerializeField] private List<DictionaryElement<TKey, TValue>> _dictionary;
        public Dictionary<TKey, TValue> GetDictionary() 
            => _dictionary.ToDictionary(key => key.Key, value => value.Value);

        public TValue this[TKey key] => _dictionary.Find(elem=>elem.Key.GetHashCode() == key.GetHashCode()).Value;
    }

    [Serializable]
    class DictionaryElement<TKey, TValue>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;
        public TKey Key => _key;
        public TValue Value => _value;
    }
}