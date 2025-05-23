using System.Collections;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem
{
    public class DaysSwitcherViewAnimator : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private DaysSwitcher _daysSwitcher;
        [SerializeField] private float _timeBetweenDays;
        [SerializeField] private CanvasGroup _sleepWindow;
        [SerializeField] private TextMeshProUGUI _dayNumberText;
        
        private void Awake() => _daysSwitcher.OnDayStarted += StartSwitching;

        private void OnEnable() => StartSwitching();
        private void OnDestroy() => _daysSwitcher.OnDayStarted -= StartSwitching;
        
        private void StartSwitching()
        {
            _sleepWindow.gameObject.SetActive(true);
            StartCoroutine(SwitchDay());
        }
        private IEnumerator SwitchDay()
        {
            yield return StartCoroutine(ShowWindow());
            
            yield return new WaitForSeconds(_timeBetweenDays);
            _dayNumberText.gameObject.SetActive(true);
            yield return new WaitForSeconds(_timeBetweenDays);
            
            yield return StartCoroutine(HideWindow());
            
            _dayNumberText.gameObject.SetActive(false);
            _sleepWindow.gameObject.SetActive(false);
        }
        private IEnumerator ShowWindow()
        {
            while (_sleepWindow.alpha < 1)
            {
                _sleepWindow.alpha += _speed * Time.deltaTime;
                yield return null;
            }
        }
        private IEnumerator HideWindow()
        {
            while (_sleepWindow.alpha > 0)
            {
                _sleepWindow.alpha -= _speed * Time.deltaTime;
                yield return null;
            }
        }
    }
}