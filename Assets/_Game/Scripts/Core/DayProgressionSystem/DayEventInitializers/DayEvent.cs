using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem.DayEventInitializers
{
    public abstract class DayEvent : MonoBehaviour
    {
        [SerializeField] private bool _isCompleted;
        
        public void Complete() => _isCompleted = true;
        
        public abstract void Initialize();
        public abstract void UnInitialize();
    }
}