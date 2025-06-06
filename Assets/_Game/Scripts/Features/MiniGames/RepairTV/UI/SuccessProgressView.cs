using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.RepairTV.UI
{
    public class SuccessProgressView:MonoBehaviour
    {
        [SerializeField] private List<GameObject> _successPhaseObjects;
        [SerializeField] TargetWeightPointPositionsChecker _targetWeightPointPositionsChecker;
        private void OnEnable()
        {
            _targetWeightPointPositionsChecker.AntennaDegreeCorrectnessChanged += UpdateView;
            UpdateView(0);
        }


        private void OnDisable()
        {
            _targetWeightPointPositionsChecker.AntennaDegreeCorrectnessChanged -= UpdateView;
        }

        private void UpdateView(float successProgress)
        {
            EnablePhaseObject(GetSpriteIndex(successProgress));
        }

        private void EnablePhaseObject(int index)
        {
            _successPhaseObjects.ForEach(obj => obj.SetActive(false));
            _successPhaseObjects[index].SetActive(true);
        }

        private int GetSpriteIndex(float successProgress)
        {
            successProgress = Mathf.Clamp01(successProgress);
            if (successProgress > 0.9f)
                return _successPhaseObjects.Count - 1;
            
            int index = Mathf.Clamp(Mathf.FloorToInt(successProgress * (_successPhaseObjects.Count - 1)), 0, _successPhaseObjects.Count-1);
            return index;
        }
    }
}