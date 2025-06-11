using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class ResultConnectionNotifier:MiniGameResultNotifier
    {
        public override event Action<bool> OnResult;
        [SerializeField] private List<LampConnectionCheckNotifier> _lampConnectionCheckNotifiers;

        private void OnEnable()
        {
            _lampConnectionCheckNotifiers.ForEach(notifier=>notifier.OnConnected += NotifyResult);
        }
        
        private void OnDisable()
        {
            _lampConnectionCheckNotifiers.ForEach(notifier=>notifier.OnConnected -= NotifyResult);
        }

        private void NotifyResult(bool connectionResult)
        {
            OnResult_UE.Invoke(connectionResult);
            OnResult?.Invoke(connectionResult);
        }
    }
}