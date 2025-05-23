using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem.DayEventInitializers
{
    public class KnifeAppearEvent : DayEvent
    {
        [SerializeField] private GameObject _knife;

        public override void Initialize()
        {
            _knife.SetActive(true);
            Debug.Log($"Event KnifeAppearEvent initialized");
        }

        public override void UnInitialize()
        {
            throw new System.NotImplementedException();
        }
    }
}