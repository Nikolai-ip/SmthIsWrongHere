using System;
using System.Linq;
using _Game.Scripts.Core.SpaceSystem;
using UnityEngine;

namespace _Game.Scripts.Common.Utilities
{
    public class CameraTrSetter:MonoBehaviour
    {
        public int RoomID;
        public int DoorID;
        public Camera _camera;
        public GameObject Character;
        public bool Update;
        private void OnValidate()
        {
            if (!Update) return;
            var roomContext = ObjectsFinder.FindObjects<RoomContext>().First(roomContext=>roomContext.ID==RoomID);
            _camera.transform.position = roomContext.CameraPlace.position;
            _camera.transform.rotation = roomContext.CameraPlace.rotation;
            var characterPlace = roomContext.DoorTransitions[DoorID].SpawnPlace;
            Character.transform.position = characterPlace.position;
            Character.transform.forward = characterPlace.forward;
        }
    }
}