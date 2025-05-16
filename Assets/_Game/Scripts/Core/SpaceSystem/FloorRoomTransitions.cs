using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    [CreateAssetMenu(fileName = "FloorRoomTransitions", menuName = "StaticData/FloorRoomTransitions")]
    public class FloorRoomTransitions: ScriptableObject
    {
        [Header("Key - Door ID, Value - Room ID")]
        [SerializeField] private DictionaryInspector<int, int> _roomTransitions;

        public bool TryGetRoomID(int doorID, out int roomID)
        {
            var roomTransitions = _roomTransitions.GetDictionary();
            return roomTransitions.TryGetValue(doorID, out roomID);
        }
    }
}