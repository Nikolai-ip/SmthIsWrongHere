using _Game.Scripts.Features;
using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem.RoomTransitonHandlers
{
    public class CharacterRotateModeSwitch:MonoBehaviour, IRoomTransitionEventHandler
    {
        [SerializeField] private ForwardToCameraRotator _characterCameraRotator;
        [SerializeField] private Vector3 _characterCameraRotatorRotation;
        public void OnExit()
        {
            _characterCameraRotator.enabled = true;
        }

        public void OnEnter()
        {
            _characterCameraRotator.enabled = false;
            _characterCameraRotator.transform.eulerAngles = _characterCameraRotatorRotation;
        }
    }
}