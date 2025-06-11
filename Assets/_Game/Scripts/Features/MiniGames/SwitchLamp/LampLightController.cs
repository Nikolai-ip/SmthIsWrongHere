using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class LampLightController:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private GameObject _light;
        [SerializeField] private LampConnectionCheckNotifier _lampConnectionCheckNotifier;
        private MiniGameContext _context;
        
        private void OnEnable()
        {
            _context.OnReset += ResetObjectState;
            _lampConnectionCheckNotifier.OnConnected += HandleResult;
        }
        private void ResetObjectState() => _light.SetActive(false);

        private void HandleResult(bool result)
        {
            if (result)
                _light.SetActive(true);
        }

        public void Apply(MiniGameContext context) => _context = context;

        private void OnDisable()
        {
            _context.OnReset -= ResetObjectState;
            _lampConnectionCheckNotifier.OnConnected -= HandleResult;
        }
    }
}