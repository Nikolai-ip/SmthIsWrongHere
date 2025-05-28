using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Core.SpaceSystem.RoomTransitonHandlers;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomContext:MonoBehaviour
    {
        [field: SerializeField] public int ID { get; private set; }
        [SerializeField] private Transform _cameraPlace;
        [Header("Key - Opening door ID, Value - OpeningPlace")]
        private Dictionary<int, DoorContext> _doorTransitions;
        public Transform CameraPlace => _cameraPlace;
        public Dictionary<int, DoorContext> DoorTransitions => _doorTransitions;
        private List<IRoomTransitionEventHandler> _roomTransitionEventHandlers;
        
        private void Awake()
        {
            _doorTransitions = GetComponentsInChildren<DoorContext>().ToDictionary(key=>key.DoorID, value=>value);
            _roomTransitionEventHandlers = GetComponentsInChildren<IRoomTransitionEventHandler>().ToList();
        }


        public void OnExitRoom()
        {
            _roomTransitionEventHandlers.ForEach(handler=>handler.OnExit());   
        }

        public void OnEnterRoom()
        {
            _roomTransitionEventHandlers.ForEach(handler=>handler.OnEnter());
        }
    }
}