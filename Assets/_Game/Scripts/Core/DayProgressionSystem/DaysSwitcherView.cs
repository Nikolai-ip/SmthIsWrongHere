using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem
{
    public class DaysSwitcherView : MonoBehaviour
    {
        [SerializeField] private DaysSwitcher _daysSwitcher;
        [SerializeField] private UIWindow _sleepWindow;

        private void Awake() => _daysSwitcher.OnDayStarted += StartSwitching;
        private void OnDestroy() => _daysSwitcher.OnDayStarted -= StartSwitching;

        private void StartSwitching()
        {
            _sleepWindow            
        }
    }
}