using System;
using UnityEngine;

namespace _Game.Scripts.Common.Utilities
{
    public class SphereGizmos: MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private Color _color;
        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}