using TMPro;
using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem
{
    public class DaysSwitcherView : MonoBehaviour
    {
        [SerializeField] private DaysSwitcher _daysSwitcher;
        [SerializeField] private TextMeshProUGUI _dayNumberText;

        private void Awake()
        {
            _daysSwitcher.OnDayStarted += Refresh;
            Refresh();
        }

        private void Refresh() => _dayNumberText.text = $"Day {_daysSwitcher.CurrentDayIndex + 1}";
    }
}