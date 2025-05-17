using UnityEngine;

namespace _Game.Scripts.Features.Player.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody _rb;
        private float Speed => _speed * Time.deltaTime;

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z) * Speed;
            
            _rb.linearVelocity = new Vector3(move.x, 0, move.z);
            
            _animator.SetBool("Walking", !Mathf.Approximately(x, 0f) || !Mathf.Approximately(z, 0f));
            
            if (!Mathf.Approximately(x, 0f))
                _spriteRenderer.flipX = move.x < 0;
        }
    }
}