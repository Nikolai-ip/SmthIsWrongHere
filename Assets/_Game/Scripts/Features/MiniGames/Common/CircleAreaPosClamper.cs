using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class CircleAreaPosClamper:MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private Transform _centerTr;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _offsetCenter;
        private Vector2 Center => (Vector2)_centerTr.position + _offsetCenter;
        public void Clamp()
        {
            float distanceFromCenterToTarget = Vector2.Distance(Center, _target.position);
            if (distanceFromCenterToTarget > _radius)
            {
                Vector2 dir = ((Vector2)_target.position - Center).normalized;
                dir *= _radius;
                _target.position = Center+dir;
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(Center,_radius);
        }
    }
}