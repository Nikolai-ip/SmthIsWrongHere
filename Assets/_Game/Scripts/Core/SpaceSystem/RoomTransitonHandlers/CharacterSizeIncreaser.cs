using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem.RoomTransitonHandlers
{
    public class CharacterSizeIncreaser:MonoBehaviour, IRoomTransitionEventHandler
    {
        [SerializeField] private Vector3 _increasedSize;
        [SerializeField] private Transform _character;
        private Vector2 _originSize;
        public void OnEnter()
        {
            _originSize = _character.localScale;
            _character.localScale = _increasedSize;
        }

        public void OnExit()
        {
            _character.localScale = _originSize;
        }
    }
}