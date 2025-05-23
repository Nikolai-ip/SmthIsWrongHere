using System;
using Tools.DevTools;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.RepairTV
{
    public class TargetWeightPointPositionsChecker:MonoBehaviour
    {
        [SerializeField] private AntennaMediator _leftAntenna;
        [SerializeField] private AntennaMediator _rightAntenna;
        [SerializeField] private Transform _targetLeftWeightPoint;
        [SerializeField] private Transform _targetRightWeightPoint;
        [SerializeField] private float _minDistanceToSuccess;
        [SerializeField] private float _maxDistanceToSuccess;
        [SerializeField, ReadOnly] private float _antennasDegreeCorrectness;
        [SerializeField, ReadOnly] private float _rightAntennaDegreeCorrectness;
        [SerializeField, ReadOnly] private float _leftAntennaDegreeCorrectness;
        public float AntennasDegreeCorrectness => _antennasDegreeCorrectness;
        public event Action<float> AntennaDegreeCorrectnessChanged;
        public event Action<bool> OnAllAntennasAreCorrectChanged;
        private void OnEnable()
        {
            _leftAntenna.OnWeightPointPosChanged += CheckLeftAntenna;
            _rightAntenna.OnWeightPointPosChanged += CheckRightAntenna;
            CheckRightAntenna(_leftAntenna.WeightPointPos);
            CheckLeftAntenna(_rightAntenna.WeightPointPos);
        }

        private void OnDisable()
        {
            _leftAntenna.OnWeightPointPosChanged -= CheckLeftAntenna;
            _rightAntenna.OnWeightPointPosChanged -= CheckRightAntenna;
        }
        private void CheckRightAntenna(Vector2 weightPoint)
        {
            AntennaCurveIsValid(weightPoint, _targetRightWeightPoint, out _rightAntennaDegreeCorrectness);
            SetDegreeCorrectnessValue();
        }
        private void CheckLeftAntenna(Vector2 weightPoint)
        {
            AntennaCurveIsValid(weightPoint, _targetLeftWeightPoint, out _leftAntennaDegreeCorrectness);
            SetDegreeCorrectnessValue();
            
        }
        private void SetDegreeCorrectnessValue()
        {
            _antennasDegreeCorrectness = (_rightAntennaDegreeCorrectness+_leftAntennaDegreeCorrectness)/2;
            AntennaDegreeCorrectnessChanged?.Invoke(_antennasDegreeCorrectness);
            OnAllAntennasAreCorrectChanged?.Invoke(_antennasDegreeCorrectness >=0.9);
        }

        /// <param name="validValue">Vallid value is a decimal between 0 and 1, define the degree correctness</param>
        private bool AntennaCurveIsValid(Vector2 weightPoint, Transform target, out float validValue)
        { 
            float distance = Vector2.Distance(weightPoint, target.position);
            validValue = Math.Abs(distance / _maxDistanceToSuccess - 1);
            return distance < _minDistanceToSuccess;
        }
    }
}