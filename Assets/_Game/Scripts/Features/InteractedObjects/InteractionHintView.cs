using _Game.Scripts.Core.Triggers;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class InteractionHintView : MonoBehaviour
    {
        [SerializeField] private BaseTrigger _trigger;
        [SerializeField] private GameObject _hintView;

        private void OnEnable()
        {
            _trigger.OnEnter += ShowHint;
            _trigger.OnExit += HideHint;
        }
        private void OnDisable()
        {
            _trigger.OnEnter -= ShowHint;
            _trigger.OnExit -= HideHint;
        }
        
        private void ShowHint() => _hintView.SetActive(true);
        private void HideHint() => _hintView.SetActive(false);
    }
}