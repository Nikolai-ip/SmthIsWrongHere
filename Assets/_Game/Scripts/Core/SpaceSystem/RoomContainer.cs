using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomContainer
    {
        private readonly List<RoomContext> _rooms = ObjectsFinder.FindObjects<RoomContext>();
        public bool TryGetRoomByID(int roomID, out RoomContext room)
        {
            room = null;
            room = _rooms.FirstOrDefault(room=>room.ID == roomID);
            if (room == null)
            {
                Debug.LogError($"Doesn't exist a room with ID {roomID}");
                return false;
            }
            return true;
        }
    }
}