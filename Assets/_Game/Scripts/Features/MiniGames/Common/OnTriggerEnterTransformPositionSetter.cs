using System;
using _Game.Scripts.Core.Triggers;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class OnTriggerEnterTransformPositionSetter:MonoBehaviour
    {
        [SerializeField] private BaseTrigger _trigger;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2Int _availableAxis;
        private void OnEnable()
        {
            _trigger.OnEnter += SetPosition;
        }

        private void OnDisable()
        {
            _trigger.OnEnter -= SetPosition;
        }

        private void OnValidate() => _availableAxis = new Vector2Int(Mathf.Clamp(_availableAxis.x,0, 1), Mathf.Clamp(_availableAxis.y,0, 1));

        private void SetPosition(GameObject collidedObject)
        {

            transform.position = new Vector3(
                _availableAxis.x != 0? _target.position.x : transform.position.x,
                _availableAxis.y != 0? _target.position.y : transform.position.y);
        }
    }
}