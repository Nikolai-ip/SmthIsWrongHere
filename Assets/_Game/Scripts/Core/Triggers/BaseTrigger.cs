using System;
using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Core.Triggers
{
    public class BaseTrigger : MonoBehaviour
    {
        private readonly AvailableCollisionValidator _collisionValidator = new();
        [SerializeField] private LayerMask _validLayerMask;
        public event Action<GameObject> OnEnter;
        public event Action<GameObject> OnStay;
        public event Action<GameObject> OnExit;
        protected void RaiseTriggerEnter(GameObject gameObject)
        {
            if (_collisionValidator.IsValid(gameObject, _validLayerMask))
                OnEnter?.Invoke(gameObject);
        }

        protected void RaiseTriggerStay(GameObject gameObject)
        {
            if (_collisionValidator.IsValid(gameObject, _validLayerMask))
                OnStay?.Invoke(gameObject);
        }

        protected void RaiseTriggerExit(GameObject gameObject)
        {
            if (_collisionValidator.IsValid(gameObject, _validLayerMask))
                OnExit?.Invoke(gameObject);
        }
    }
}
