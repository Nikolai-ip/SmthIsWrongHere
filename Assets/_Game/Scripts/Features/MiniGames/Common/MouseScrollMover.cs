using System;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class MouseScrollMover:MonoBehaviour
    {
        [SerializeField] private Transform _movable;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private Vector2 _movement;

        private void OnEnable()
        {
            _inputListener.OnMouseScroll += Move;
        }
        private void OnDisable()
        {
            _inputListener.OnMouseScroll -= Move;
        }
        private void Move(float scrollValue) => _movable.Translate(_movement * scrollValue);
    }
}