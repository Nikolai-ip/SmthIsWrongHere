using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class PointFollower:MonoBehaviour, IMiniGameContextApplier
    {
        [SerializeField] private EntityPointerListener _pointerListener;
        [SerializeField] private Transform _target;
        private InputListener _inputListener;
        private bool _isFollowing;
        private Vector2 _offset;
        public event Action<Vector2> OnMoved;
        private void OnEnable()
        {
            _pointerListener.onPointerDown += StartDrag;
            _pointerListener.onPointerUp += StopDrag;
        }

        private void OnDisable()
        {
            _pointerListener.onPointerDown -= StartDrag;
            _pointerListener.onPointerUp -= StopDrag;
        }

        private void StartDrag(PointerEventData eventData)
        {
            _isFollowing = true;
            _offset = (Vector2)_target.position - _inputListener.MousePos;
        }

        private void StopDrag(PointerEventData obj)
        {
            _isFollowing = false;
            _offset = Vector2.zero;
        }

        private void Update()
        {
            if (_isFollowing)
            {
                _target.position = _inputListener.MousePos + _offset;
                OnMoved?.Invoke(_target.position);
            }
        }

        public void Apply(MiniGameContext context)
        {
            _inputListener = context.InputListener;
        }
    }
}