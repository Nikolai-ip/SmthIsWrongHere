using _Game.Scripts.Core.Infrastructure;
using _Game.Scripts.Core.Signals;
using _Game.Scripts.Core.SpaceSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class DoorInteracted: InteractedMono
    {
        [SerializeField] private DoorContext _doorContext;
        [SerializeField] private RoomContext _roomContext;
        public override void Interact(GameObject @this)
        {
            base.Interact(@this);
            EventBus.Invoke(new RoomTransitionSignal(new RoomTransitionArgs(_doorContext.DoorID, _roomContext.ID)));
        }
    }
}