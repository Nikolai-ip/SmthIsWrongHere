using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem.DayEventInitializers
{
    public class DayEventsInitializer : MonoBehaviour
    {
        [SerializeField] private DaysSwitcher _daysSwitcher;

        private void OnEnable() => _daysSwitcher.OnDayStarted += Initialize;
        private void OnDestroy() => _daysSwitcher.OnDayStarted += Initialize;

        public void Initialize()
        {
            var currentDay = _daysSwitcher.CurrentDay;
            
            currentDay.DayEvents.ForEach(e => e.Initialize());
        }
    }
}