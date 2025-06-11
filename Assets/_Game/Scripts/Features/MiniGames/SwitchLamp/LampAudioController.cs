using System;
using System.Collections;
using _Game.Scripts.Core.Triggers;
using _Game.Scripts.Features.MiniGames.Common;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class LampAudioController:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private LampAudioReproducer _lampAudioReproducer;
        [SerializeField] private MouseScrollMover _lampScrollMover;
        [SerializeField] private MiniGameResultNotifier _resultNotifier;
        private bool _canPlayScrollSounds;
        [SerializeField] private float _delayBetweenConnectingSounds;
        [SerializeField] private BaseTrigger _connectingRailTrigger;
        private MiniGameContext _context;
        private void PlayOnConnectingRailOutSound(GameObject rail) => _lampAudioReproducer.PlaySound(LampAudioReproducer.Sounds.ConnectOut);
        
        private void OnEnable()
        {
            _lampScrollMover.OnMove += PlayConnectingSound;
            _connectingRailTrigger.OnExit += PlayOnConnectingRailOutSound;
            _resultNotifier.OnResult += PlayResultSound;
            _context.OnReset += ResetAudioController;
        }

        private void ResetAudioController() => _canPlayScrollSounds = true;

        private void PlayResultSound(bool success)
        {
            if (success)
                _lampAudioReproducer.PlaySound(LampAudioReproducer.Sounds.ValidConnection);
            else
            {
                StopAllCoroutines();
                _canPlayScrollSounds = false;
                _lampAudioReproducer.PlaySound(LampAudioReproducer.Sounds.NotValidConnection);
            }
        }
        
        private void PlayConnectingSound(Vector2 position)
        {
            if (!_canPlayScrollSounds) return;
            _lampAudioReproducer.PlayRandomSound(LampAudioReproducer.Sounds.Connecting);
            _canPlayScrollSounds = false;
            StartCoroutine(EnableCanPlayScrollSounds());
        }

        private IEnumerator EnableCanPlayScrollSounds()
        {
            yield return new WaitForSeconds(_delayBetweenConnectingSounds);
            _canPlayScrollSounds = true;
        }

        public void Apply(MiniGameContext context) => _context = context;

        private void OnDisable()
        {
            _lampScrollMover.OnMove -= PlayConnectingSound;
            _connectingRailTrigger.OnExit -= PlayOnConnectingRailOutSound;
            _context.OnReset -= ResetAudioController;
        }
    }
}