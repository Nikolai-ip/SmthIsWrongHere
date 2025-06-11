using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class GlobalLightController:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private Light2D _light;
        [SerializeField] private float _failedIntensity;
        [SerializeField] private MiniGameResultNotifier _miniGameResultNotifier;
        private MiniGameContext _context;
        private float _originalIntensity;
        private void OnEnable()
        {
            _originalIntensity = _light.intensity;
            _context.OnReset += ResetObjectState;
            _miniGameResultNotifier.OnResult += HandleResult;
        }

        private void OnDisable()
        {
            _context.OnReset -= ResetObjectState;
            _miniGameResultNotifier.OnResult -= HandleResult;
        }

        private void ResetObjectState() => _light.intensity = _originalIntensity;

        private void HandleResult(bool result)
        {
            if (!result)
                _light.intensity = _failedIntensity;
            
        }

        public void Apply(MiniGameContext context) => _context = context;
    }
}