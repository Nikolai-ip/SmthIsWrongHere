using System;
using _Game.Scripts.Features.MiniGames.Common;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.RepairTV
{
    public class AntennaMediator:MonoBehaviour
    {
        [SerializeField] private CurveDrawer _curveDrawer;
        [SerializeField] private Transform _lineStartTr;
        [SerializeField] private Transform _lineEndTr;
        [SerializeField] private Transform _weightTr;
        [SerializeField] private PointFollower _weightTrFollower;
        [SerializeField] private CircleAreaPosClamper _weightPointPosClamper;
        public Vector2 WeightPointPos => _weightTr.position;
        public event Action<Vector2> OnWeightPointPosChanged;
        private void OnEnable()
        {
            _weightTrFollower.OnMoved += OnWeightPointMove;
        }

        private void Start()
        {
            _weightTr.position= _lineStartTr.position + (_lineEndTr.position - _lineStartTr.position)/2;
            _curveDrawer.DrawCurve(_lineStartTr.position, _lineEndTr.position, _weightTr.position);
        }

        private void OnWeightPointMove(Vector2 pos)
        {
            _weightPointPosClamper.Clamp();
            OnWeightPointPosChanged?.Invoke(_weightTr.position);
            _curveDrawer.ClearLine();
            _curveDrawer.DrawCurve(_lineStartTr.position, _lineEndTr.position, _weightTr.position);
        }

        private void OnDisable()
        {
            _weightTrFollower.OnMoved -= OnWeightPointMove;
        }
    }
}