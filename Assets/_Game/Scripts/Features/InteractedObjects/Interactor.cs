using _Game.Scripts.Core.Triggers;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private BaseTrigger _trigger;
        [SerializeField] private BaseAction _action;
        [SerializeField] private bool _canInteract;

        private void OnEnable()
        {
            _trigger.OnEnter += SwitchCanInteract;
            _trigger.OnExit += SwitchCanInteract;
        }
        private void OnDisable()
        {
            _trigger.OnEnter -= SwitchCanInteract;
            _trigger.OnExit -= SwitchCanInteract;
        }

        private void Update()
        {
            if (!_canInteract)
                return;

            if (_action.IsPerforming)
                return;
            
            if (Input.GetKeyDown(KeyCode.E)) 
                _action.Perform();
        }

        private void SwitchCanInteract() => _canInteract = !_canInteract;
    }
}