using _Game.Scripts.Core.DayProgressionSystem;
using _Game.Scripts.Features.InteractedObjects;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class BedSleeper : InteractedMono
    {
        [SerializeField] private DaysSwitcher _daysSwitcher;

        public override void Interact(GameObject @this)
        {
            base.Interact(@this);
            _daysSwitcher.AdvanceDay();
        }
    }
}