using _Game.Scripts.Core.Triggers;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private BaseTrigger _trigger;
        [SerializeField] private BaseAction _action;
        [SerializeField] private bool CanInteract = false;

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
            if (!CanInteract)
                return;

            if (_action.IsPerforming)
                return;
            
            if (Input.GetKeyDown(KeyCode.E)) 
                _action.Perform();
        }

        private void SwitchCanInteract() => CanInteract = !CanInteract;
    }
}