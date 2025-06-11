using _Game.Scripts.Features.MiniGames.SwitchLamp;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class OnMiniGameResultActiveObjectSetter:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private MiniGameResultNotifier _miniGameResultNotifier;
        private MiniGameContext _context;
        [SerializeField] private bool _invert;
        private bool _originEnabled;

        private void OnEnable()
        {
            _originEnabled = _object.activeSelf;
            _context.OnReset += ResetObjectState;
            _miniGameResultNotifier.OnResult += HandleResult;
        }

        private void OnDisable()
        {
            _context.OnReset -= ResetObjectState;
            _miniGameResultNotifier.OnResult -= HandleResult;
        }

        private void ResetObjectState()
        {
            _object.SetActive(_originEnabled);
        }

        private void HandleResult(bool result)
        {
            _object.SetActive(_invert? !result: result);
        }

        public void Apply(MiniGameContext context)
        {
            _context = context;
        }
    }
}