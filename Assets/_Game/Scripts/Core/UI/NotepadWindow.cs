using _Game.Scripts.Core.DayProgressionSystem;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Core.InventorySystem
{
    public class NotepadWindow : UIWindow
    {
        [SerializeField] private DaysSwitcher _daysSwitcher;
        [SerializeField] private TextMeshProUGUI _dayNumberText;

        private void OnEnable()
        {
            _daysSwitcher.OnDayStarted += Refresh;
            Refresh();
        }

        private void OnDestroy() => _daysSwitcher.OnDayStarted -= Refresh;

        private void Refresh()
        {
            _dayNumberText.text = (_daysSwitcher.CurrentDayIndex + 1).ToString();
            
            
        }
    }
}