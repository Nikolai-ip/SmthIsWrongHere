using UnityEngine;

namespace _Game.Scripts.Features.Player.Movement
{
    public class Mover : MonoBehaviour
    {
        public const float Gravity = -9.81f;
        
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public float Speed => _speed * Time.deltaTime;

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            _characterController.Move(move * Speed);

            _animator.SetBool("Walking", !Mathf.Approximately(x, 0f) || !Mathf.Approximately(z, 0f));
            
            if (!Mathf.Approximately(x, 0f))
                _spriteRenderer.flipX = move.x < 0;

            SetGravity();
        }

        private void SetGravity() => _characterController.Move(Vector3.up * Gravity * Time.deltaTime);
    }
}