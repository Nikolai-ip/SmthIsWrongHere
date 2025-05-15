using System;
using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Core.Triggers
{
    public class BaseTrigger : MonoBehaviour
    {
        public event Action OnEnter;
        public event Action OnExit;
        protected void RaiseTriggerEnter() => OnEnter?.Invoke();
        protected void RaiseTriggerExit() => OnExit?.Invoke();
    }
}
