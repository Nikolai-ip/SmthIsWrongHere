using System.Collections.Generic;
using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomContext:MonoBehaviour
    {
        [field: SerializeField] public int ID { get; private set; }
        [SerializeField] private Transform _cameraPlace;
        [Header("Key - OpeningRoomID, Value - OpeningPlace")]
        [SerializeField] private DictionaryInspector<int, DoorContext> _doorTransitionsInspector;
        private Dictionary<int, DoorContext> _doorTransitions;
        public Transform CameraPlace => _cameraPlace;
        public Dictionary<int, DoorContext> DoorTransitions
        {
            get
            {
                _doorTransitions ??= _doorTransitionsInspector.GetDictionary();
                return _doorTransitions;
            }
        }
    }
}