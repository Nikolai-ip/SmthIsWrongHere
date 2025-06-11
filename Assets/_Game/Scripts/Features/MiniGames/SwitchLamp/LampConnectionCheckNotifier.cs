using System;
using _Game.Scripts.Core.Triggers;
using _Game.Scripts.Features.MiniGames.Common;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class LampConnectionCheckNotifier: MonoBehaviour
    {
        [SerializeField] private BaseTrigger _connectorTrigger;
        [SerializeField] private IDComponent _lampIdComponent;

        public event Action<bool> OnConnected;
        private void OnEnable()
        {
            _connectorTrigger.OnEnter += CheckConnection;
        }

        private void OnDisable()
        {
            _connectorTrigger.OnEnter -= CheckConnection;
        }

        private void CheckConnection(GameObject collidedObj)
        {
            if (collidedObj.TryGetComponent(out IDComponent connectorIdComponent))
                OnConnected?.Invoke(connectorIdComponent.ID == _lampIdComponent.ID);
            
        }
    }
}