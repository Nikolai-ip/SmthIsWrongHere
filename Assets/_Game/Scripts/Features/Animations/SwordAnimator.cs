using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Features.Animations
{
    public class SwordAnimator : MonoBehaviour
    {
        private Transform _transform;
        private Vector3 _startPosition;

        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _frequency = 1f; 
        [SerializeField] private float _amplitude = 1f; 

        private void Awake()
        {
            _transform = transform;
            _startPosition = transform.position;
        }

        private void Update()
        {
            _transform.Rotate(Vector3.up * (_rotationSpeed * Time.deltaTime), Space.World);

            float newY = _startPosition.y + Mathf.Sin(Time.time * _frequency) * _amplitude;
            transform.position = new Vector3(_startPosition.x, newY, _startPosition.z);
        }
    }
}