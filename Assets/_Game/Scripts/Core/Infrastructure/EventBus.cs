using System;
using System.Collections.Generic;
using _Game.Scripts.Core.Signals;
using UnityEngine;

namespace _Game.Scripts.Core.Infrastructure
{
    public class EventBus
    {
        private static Dictionary<Type, List<Delegate>> _signalCallbacks;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void UpdateMemory()
        {
            _signalCallbacks = new Dictionary<Type, List<Delegate>>();
        }
        public static void Subscribe<T>(Action<T> callBack) where T:ISignal
        {
            var key = typeof(T);
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Add(callBack);   
            }
            else
            {
                _signalCallbacks.Add(key,new List<Delegate>{callBack});
            }
        }
        public static void RemoveCallback<T>(Action<T> callBack) where T : ISignal
        {
            var key = typeof(T);
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Remove(callBack);
            }
        }
        
        public static void Invoke<T>(T signal) where T:ISignal
        {
            if (_signalCallbacks.TryGetValue(signal.GetType(), out var actions))
            {
                InvokeActions(actions,signal);
            }
            else
            {
                Debug.LogWarning($"The EventBus has not a value with the key: {signal.ToString()}");
            }
        }
        private static void InvokeActions(List<Delegate> actions, ISignal signal)
        {
            var actionsCopy = new List<Delegate>(actions);
            foreach (var action in actionsCopy)
            {
                action.DynamicInvoke(signal);
            }
        }
        
    }
    
}