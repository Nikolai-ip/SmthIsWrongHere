using _Game.Scripts.Core.DayProgressionSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public class BedSleeper : MonoBehaviour, IInteractable
    {
        [SerializeField] private DaysSwitcher _daysSwitcher;

        public void Interact(GameObject @this)
        {
            _daysSwitcher.AdvanceDay();
        }
    }
}