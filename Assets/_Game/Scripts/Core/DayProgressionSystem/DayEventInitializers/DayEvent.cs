using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem.DayEventInitializers
{
    public class DayEvent : MonoBehaviour
    {
        [SerializeField] private bool _isCompleted;
        
        public void Complete() => _isCompleted = true;
    }
}