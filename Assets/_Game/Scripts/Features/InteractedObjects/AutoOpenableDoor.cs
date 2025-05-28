using System;
using _Game.Scripts.Core.Infrastructure;
using _Game.Scripts.Core.Signals;
using _Game.Scripts.Core.SpaceSystem;
using _Game.Scripts.Core.Triggers;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class AutoOpenableDoor:DoorContext
    {
        [SerializeField] private BaseTrigger _trigger;
        [SerializeField] private RoomContext _roomContext;

        private void OnEnable()
        {
            _trigger.OnEnter += InvokeRoomTransitionSignal;
        }

        private void OnDisable()
        {
            _trigger.OnEnter -= InvokeRoomTransitionSignal;
        }

        private void InvokeRoomTransitionSignal(GameObject player)
        {
            EventBus.Invoke(new RoomTransitionSignal(new RoomTransitionArgs(DoorID, _roomContext.ID)));
        }
    }
}