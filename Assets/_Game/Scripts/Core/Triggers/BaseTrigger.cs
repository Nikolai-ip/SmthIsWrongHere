using System;
using UnityEngine;

namespace _Game.Scripts.Core.Triggers
{
    public class BaseTrigger : MonoBehaviour
    {
        public event Action<GameObject> OnEnter;
        public event Action<GameObject> OnStay;
        public event Action<GameObject> OnExit;
        protected void RaiseTriggerEnter(GameObject gameObject) => OnEnter?.Invoke(gameObject);
        protected void RaiseTriggerStay(GameObject gameObject) => OnStay?.Invoke(gameObject);
        protected void RaiseTriggerExit(GameObject gameObject) => OnExit?.Invoke(gameObject);
    }
}
