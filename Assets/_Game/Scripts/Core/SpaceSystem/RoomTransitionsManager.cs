using System;
using _Game.Scripts.Core.Infrastructure;
using _Game.Scripts.Core.Signals;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomTransitionsManager: IDisposable
    { 
        private readonly RoomContainer _roomContainer;
        private readonly FloorRoomTransitions[] _floorRoomTransitions;
        private readonly RoomTransitionApplier _roomTransitionApplier;
        private FloorRoomTransitions _currentFloorRoomTransition;

        public RoomTransitionsManager(RoomContainer roomContainer, FloorRoomTransitions[] floorRoomTransitions, RoomTransitionApplier roomTransitionApplier)
        {
            _roomContainer = roomContainer;
            _floorRoomTransitions = floorRoomTransitions;
            _roomTransitionApplier = roomTransitionApplier;
            EventBus.Subscribe<RoomTransitionSignal>(OnRoomTransition);
        }
        
        public void SetFloor(int floorNumber)
        {
            if (floorNumber < 0 || floorNumber >= _floorRoomTransitions.Length)
            {
                Debug.LogError($"Out of index exception: {floorNumber}");
                return;
            }
            _currentFloorRoomTransition = _floorRoomTransitions[floorNumber];            
        }
        private void OnRoomTransition(RoomTransitionSignal signal) => DoTransition(signal.Args);

        public void DoTransition(RoomTransitionArgs args)
        {
            if (_currentFloorRoomTransition == null)
            {
                Debug.LogError("CurrentFloorRoomTransition is null, did you forget to invoke SetFloor?");
                return;
            }
            if (_currentFloorRoomTransition.TryGetRoomID(args.CurrentRoomID, args.DoorID,  out int roomID))
            {
                if (_roomContainer.TryGetRoomByID(roomID, out RoomContext roomContext))
                    _roomTransitionApplier.ApplyTransition(roomContext, args.DoorID);
            }
            else
                Debug.LogError($"Failed to get room ID with currentRoom ID = {args.CurrentRoomID} and door ID = {args.DoorID}");
            
        }

        public void Dispose()
        {
            EventBus.RemoveCallback<RoomTransitionSignal>(OnRoomTransition);
        }
    }
}