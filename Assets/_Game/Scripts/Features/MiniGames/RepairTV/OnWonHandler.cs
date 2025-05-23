using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.RepairTV
{
    public class OnWonHandler:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private TargetWeightPointPositionsChecker _targetWeightPointPositionsChecker;
        private InputListener _inputListener;
        private MiniGameContext _context;
        [SerializeField] private float _delayBeforeSuccess;
        private Coroutine _successCoroutine;
        private void OnEnable()
        {
            _targetWeightPointPositionsChecker.OnAllAntennasAreCorrectChanged += CheckWinState;
        }

        private void OnDisable()
        {
            _targetWeightPointPositionsChecker.OnAllAntennasAreCorrectChanged -= CheckWinState;
            _successCoroutine = null;
        }

        private void CheckWinState(bool isWin)
        {
            if (isWin && _successCoroutine == null)
            {
                _inputListener.Disable();
                _successCoroutine = StartCoroutine(SuccessDelay());
            }
        }

        private IEnumerator SuccessDelay()
        {
            yield return new WaitForSeconds(_delayBeforeSuccess);
            _context.OnSuccess();
        }

        public void Apply(MiniGameContext context)
        {
            _context = context;
            _inputListener = context.InputListener;
        }
    }
}