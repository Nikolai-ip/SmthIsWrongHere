using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomTransitionApplier
    {
        private readonly Transform _character;
        private readonly Camera _camera;

        public RoomTransitionApplier(Transform character, Camera camera)
        {
            _character = character;
            _camera = camera;
        }

        public void ApplyTransition(RoomContext roomContext, int doorID)
        {
            _camera.transform.position = roomContext.CameraPlace.position;
            _camera.transform.rotation = roomContext.CameraPlace.rotation;
            var characterPlace = roomContext.DoorTransitions[doorID].SpawnPlace;
            Debug.Log($"Move character to {characterPlace.name} with position {characterPlace.position}");
            _character.position = characterPlace.position;
            _character.forward = characterPlace.forward;
        }
    }
}