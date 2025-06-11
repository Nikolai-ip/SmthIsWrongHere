using _Game.Scripts.Core.Triggers;
using _Game.Scripts.Features.MiniGames.Common;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class LampInputSchemeSwitch:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private BaseTrigger _lampConnectorTrigger;
        [SerializeField] private MiniGameResultNotifier _resultNotifier;
        [SerializeField] private MouseScrollMover _mouseScrollMover;
        [SerializeField] private PointFollower _pointFollower;
        public UnityEvent<InputScheme> OnInputSchemeChanged;
        private MiniGameContext _context;
        private bool _canSwitchInputScheme = true;
        private void OnEnable()
        {
            _lampConnectorTrigger.OnEnter += SwitchScrollWheelInputScheme;
            _lampConnectorTrigger.OnExit += ResetScrollWheelInputScheme;
            if (_context != null)
                _context.OnReset += OnReset;
            _resultNotifier.OnResult += OnMiniGameResult;
        }

        private void OnReset()
        {
            _canSwitchInputScheme = true;
            _pointFollower.enabled = true;
            _mouseScrollMover.enabled = false;
        }

        private void OnMiniGameResult(bool result)
        {
            _canSwitchInputScheme = false;
            ToggleInputScheme(InputScheme.None);
        }

        private void OnDisable()
        {
            _lampConnectorTrigger.OnEnter -= SwitchScrollWheelInputScheme;
            _lampConnectorTrigger.OnExit -= ResetScrollWheelInputScheme;
            if (_context != null)
                _context.OnReset -= OnReset;
            _resultNotifier.OnResult -= OnMiniGameResult;
        }
        private void SwitchScrollWheelInputScheme(GameObject collidedObj)
        {
            if (_canSwitchInputScheme)
                ToggleInputScheme(InputScheme.MouseScroll);
        }

        private void ResetScrollWheelInputScheme(GameObject collidedObj)
        {
            if (_canSwitchInputScheme)
                ToggleInputScheme(InputScheme.Pointer);
        }

        private void ToggleInputScheme(InputScheme scheme)
        {
            _pointFollower.enabled = scheme == InputScheme.Pointer;
            _mouseScrollMover.enabled = scheme == InputScheme.MouseScroll;
            OnInputSchemeChanged?.Invoke(scheme);
        }

        public void Apply(MiniGameContext context) => _context = context;
    }
    public enum InputScheme
    {
        None,
        Pointer,
        MouseScroll,
    }
}