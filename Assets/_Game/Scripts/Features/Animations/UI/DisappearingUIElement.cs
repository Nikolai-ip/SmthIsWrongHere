using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Features.Animations.UI
{
    public abstract class DisappearingUIElement:MonoBehaviour
    {
        protected Color OriginalColor;
        [SerializeField] private bool _hideOnAwake;
        private void OnEnable()
        {
            SetOriginalColor();
            if (_hideOnAwake)
                SetColor(new Color(0, 0, 0, 0));
        }

        protected abstract void SetOriginalColor();

        private IEnumerator Disappearing(float delay, float disappearingTime)
        {
            yield return new WaitForSeconds(delay);
            float time = 0;
            Color currentColor = GetCurrentColor();
            while (time < disappearingTime)
            {
                time += Time.deltaTime;
                var color = Color.Lerp(currentColor, new Color(0,0,0,0), time / disappearingTime);
                SetColor(color);
                yield return null;
            }
        }

        protected abstract Color GetCurrentColor();
        protected abstract void SetColor(Color color);
        
        public void StartDisappearing(float delay, float disappearingTime)
        {
            ResetColor();
            StopAllCoroutines();
            StartCoroutine(Disappearing(delay, disappearingTime));
        }

        private void OnDisable()
        {
            ResetColor();
            StopAllCoroutines();
        }

        protected abstract void ResetColor();
    }
}