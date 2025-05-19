using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class CurveDrawer:MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _step;
        private readonly CurveGenerator _curveGenerator = new();
        private List<Vector2> _curvePoints;

        public void ClearLine()
        {
            _lineRenderer.positionCount = 0;
            _curvePoints?.Clear();
        }
        
        public void DrawCurve(Vector2 from, Vector2 to, Vector2 weightPoint)
        {
            _curvePoints = _curveGenerator.GerCurve(from, to, weightPoint, _step);
            for (int i = 0; i < _curvePoints.Count; i++)
            {
                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _curvePoints[i]);
            }
        }
        

    }
}