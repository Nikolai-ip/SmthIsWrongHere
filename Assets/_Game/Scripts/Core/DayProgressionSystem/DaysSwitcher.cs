using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem
{
    public class DaysSwitcher : MonoBehaviour
    {
        public List<DayContext> Days;
        
        public event Action OnDayStarted;
        public event Action OnDayEnded;
        public int CurrentDayIndex { get; private set; }
        public DayContext CurrentDay => Days[CurrentDayIndex];
        
        public void AdvanceDay()
        {
            Debug.Log(CurrentDayIndex);

            if (CurrentDayIndex >= Days.Count - 1)
                return;
            
            OnDayEnded?.Invoke();
            CurrentDayIndex++;
            OnDayStarted?.Invoke();
        }
    }
}