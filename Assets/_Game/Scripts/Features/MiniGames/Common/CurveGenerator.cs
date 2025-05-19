using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class CurveGenerator
    {
        public List<Vector2> GerCurve(Vector2 from, Vector2 to, Vector2 weightPoint, float step)
        {
            var curve = new List<Vector2>();
            float distance = Vector2.Distance(from, to);
            if (distance <= 0) return curve;
            int lineCount = Mathf.CeilToInt(distance/step);
            for (int i = 0; i <= lineCount; i++)
            {
                float t = i / (float)lineCount;
                Vector2 point = QuadraticBezier(from, weightPoint, to, t);
                curve.Add(point);
            }
            return curve;
        }
        
        private Vector2 QuadraticBezier(Vector2 a, Vector2 b, Vector2 c, float t)
        {
            return (1 - t) * (1 - t) * a + 2 * (1 - t) * t * b + t * t * c;
        }
    }
}