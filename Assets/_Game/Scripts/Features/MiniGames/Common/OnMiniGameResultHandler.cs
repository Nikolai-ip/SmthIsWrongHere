using System.Collections;
using _Game.Scripts.Features.MiniGames.SwitchLamp;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class OnMiniGameResultHandler:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private MiniGameResultNotifier _miniGameResultNotifier;
        [SerializeField] private float _onSuccessHandleDelay;
        [SerializeField] private float _onFailureHandleDelay;
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
            if (success)
            {
                yield return new WaitForSeconds(_onSuccessHandleDelay);
                _miniGameContext.OnSuccess();
            }
            else
            {
                yield return new WaitForSeconds(_onFailureHandleDelay);
                _miniGameContext.OnFailed();
            }
        }

        public void Apply(MiniGameContext context)
        {
            _miniGameContext = context;
        }
    }
}