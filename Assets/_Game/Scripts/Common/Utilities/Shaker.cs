using UnityEngine;

namespace _Game.Scripts.Common.Utilities
{
    public class Shaker:MonoBehaviour
    {
        [Tooltip("Duration of the shake in seconds.")]
        public float shakeDuration = 0.5f;
        [Tooltip("Magnitude of the shake (how much it moves).")]
        public float shakeMagnitude = 0.2f;
        [Tooltip("Damping speed for the shake to fade out.")]
        public float dampingSpeed = 2f;

        private Vector3 originalPosition;
        [SerializeField] private float _shakeDuration;
        private bool _isShaking = false;

        void Awake()
        {
            originalPosition = transform.position;
        }

        void Update()
        {
            if (_shakeDuration > 0)
            {
                _shakeDuration -= Time.deltaTime * dampingSpeed;

                if (_shakeDuration < 0)
                {
                    _shakeDuration = 0;
                    transform.position = originalPosition;
                    _isShaking = false; // Set shaking flag to false
                }
            }

            if (_isShaking)
            {
                // Apply shake effect
                transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude * _shakeDuration;
            }

        }

        public void TriggerShake()
        {
            if (!_isShaking) // Check if shaking is already happening
            {
                _isShaking = true;
            }
        }
    }
}