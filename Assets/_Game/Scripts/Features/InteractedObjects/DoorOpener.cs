using _Game.Scripts.Core.Infrastructure;
using _Game.Scripts.Core.Signals;
using _Game.Scripts.Core.SpaceSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class DoorInteracted:BaseAction
    {
        [SerializeField] private DoorContext _doorContext;
        public override bool CanPerform { get; }

        public override void Perform()
        {
            if (IsPerforming)
                return;
            IsPerforming = true;
            EventBus.Invoke(new RoomTransitionSignal(new RoomTransitionArgs(_doorContext.DoorID)));
            IsPerforming = false;
        }

        public override void UnPerform()
        {
            throw new System.NotImplementedException();
        }
    }
}