using System.Collections;
using _Game.Scripts.Features.MiniGames.SwitchLamp;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class OnMiniGameResultHandler:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private MiniGameResultNotifier _miniGameResultNotifier;
        [SerializeField] private float _handleDelay;
        private MiniGameContext _miniGameContext;

        private void OnEnable()
        {
            _miniGameResultNotifier.OnResult += HandleResult;
        }

        private void OnDisable()
        {
            _miniGameResultNotifier.OnResult -= HandleResult;
        }

        private void HandleResult(bool success)
        {
            StartCoroutine(Handle(success));
        }

        private IEnumerator Handle(bool success)
        {
            yield return new WaitForSeconds(_handleDelay);
            if (success)
                _miniGameContext.OnSuccess();
            else
                _miniGameContext.OnFailed();
        }

        public void Apply(MiniGameContext context)
        {
            _miniGameContext = context;
        }
    }
}