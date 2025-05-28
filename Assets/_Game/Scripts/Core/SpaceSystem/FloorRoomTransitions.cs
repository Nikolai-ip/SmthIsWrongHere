using System;
using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    [CreateAssetMenu(fileName = "FloorRoomTransitions", menuName = "StaticData/FloorRoomTransitions")]
    public class FloorRoomTransitions: ScriptableObject
    {
        [Header("Value - Room ID")]
        [SerializeField] private DictionaryInspector<RoomTransitionValue, int> _roomTransitions;

        public bool TryGetRoomID(int inputRoomID, int doorID, out int outputRoomID)
        {
            var roomTransitions = _roomTransitions.GetDictionary();
            return roomTransitions.TryGetValue(new RoomTransitionValue(inputRoomID, doorID), out outputRoomID);
        }
    }

    [Serializable]
    public class RoomTransitionValue
    {
        [SerializeField] private int _doorID;
        [SerializeField] private int _roomID;
        public int DoorID => _doorID;
        public int RoomID => _roomID;

        public RoomTransitionValue(int roomID, int doorID)
        {
            _doorID = doorID;
            _roomID = roomID;
        }

        public override bool Equals(object obj)
        {
            if (obj is not RoomTransitionValue other) return false;
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + _doorID;
                hash = hash * 31 + _roomID;
                return hash;
            }
        }
    } 
}