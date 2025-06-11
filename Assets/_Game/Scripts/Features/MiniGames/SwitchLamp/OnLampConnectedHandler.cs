using System;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class OnLampConnectedHandler:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private LampConnectionCheckNotifier _connectionCheckNotifier;
        [SerializeField] private GameObject _lampLight;
        [SerializeField] private LampAudioController _lampAudioController;
        private MiniGameContext _context;

        private void OnEnable()
        {
            _connectionCheckNotifier.OnConnected += HandleOnConnected;
            _context.OnReset += ResetHandler;
        }

        private void ResetHandler()
        {
            _lampLight.SetActive(false);
        }

        private void HandleOnConnected(bool result)
        {
            _lampLight.SetActive(true);
        }

        public void Apply(MiniGameContext context) => _context = context;

        private void OnDisable()
        {
            _connectionCheckNotifier.OnConnected -= HandleOnConnected;
            _context.OnReset -= ResetHandler;
        }
    }
}