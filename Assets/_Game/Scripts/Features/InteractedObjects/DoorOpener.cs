using System;
using _Game.Scripts.Core.Infrastructure;
using _Game.Scripts.Core.Signals;
using _Game.Scripts.Core.SpaceSystem;
using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class DoorInteracted:MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorContext _doorContext;
        [SerializeField] private RoomContext _roomContext;
        public event Action OnInteract;
        public void Interact(GameObject @this)
        {
            EventBus.Invoke(new RoomTransitionSignal(new RoomTransitionArgs(_doorContext.DoorID, _roomContext.ID)));
            OnInteract?.Invoke();
        }
    }
}