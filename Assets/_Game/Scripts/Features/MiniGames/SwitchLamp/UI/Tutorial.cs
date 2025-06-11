using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Game.Scripts.Features.Animations.UI;
using Tools.DevTools;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp.UI
{
    public class Tutorial: MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private List<DisappearingUIElement> _disappearingUIElements;
        [SerializeField, ReadOnly] private bool _tutorialPassed;
        [SerializeField] private float _disappearingDuration;
        [SerializeField] private float _disappearingDelay;
        public UnityEvent OnStart;
        public UnityEvent OnFinish;
        private MiniGameContext _context;

        public void ShowTutorial()
        {
            if (!_tutorialPassed)
            {
                Debug.Log($"{gameObject.name} is showing");
                _tutorialPassed = true;
                _disappearingUIElements.ForEach(element=>element.StartDisappearing(_disappearingDelay, _disappearingDuration));
                StartCoroutine(InvokeOnFinishEvent());
                OnStart?.Invoke();
            }
        }
        private void OnEnable()
        {
            _context.OnMiniGameExitResult += OnReset;
        }

        private void OnReset(MiniGameResultType result)
        {
            _tutorialPassed = false;
        }

        private void OnDisable()
        {
            _context.OnMiniGameExitResult -= OnReset;
        }

        private IEnumerator InvokeOnFinishEvent()
        {
            yield return new WaitForSeconds(_disappearingDelay);
            OnFinish?.Invoke();
        }

        public void Apply(MiniGameContext context)
        {
            _context = context;
        }
    }
}