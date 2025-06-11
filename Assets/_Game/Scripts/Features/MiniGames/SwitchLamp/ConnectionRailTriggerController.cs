using System;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class ConnectionRailTriggerController:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private Collider2D _railTrigger;
        [SerializeField] private MiniGameResultNotifier _resultNotifier;
        private MiniGameContext _context;

        private void OnEnable()
        {
            _context.OnReset += EnableTrigger;
            _resultNotifier.OnResult += DisableTrigger;
        }

        private void DisableTrigger(bool result) => _railTrigger.enabled = false;

        private void EnableTrigger() => _railTrigger.enabled = true;

        private void OnDisable()
        {
            _context.OnReset -= EnableTrigger;
            _resultNotifier.OnResult -= DisableTrigger;
        }

        public void Apply(MiniGameContext context)
        {
            _context = context;
        }
    }
}