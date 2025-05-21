using System;
using _Game.Scripts.Core.Triggers;
using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private BaseTrigger _trigger;

        private Tuple<IInteractable, InteractionHintView> _currentInteractable;
        private IInteractable _interactedObject;

        private void OnEnable()
        {
            _trigger.OnEnter += OnInteractableEnter;
            _trigger.OnExit += OnInteractableExit;
        }
        private void OnDisable()
        {
            _trigger.OnEnter -= OnInteractableEnter;
            _trigger.OnExit -= OnInteractableExit;
        }

        private void Update()
        {
            if (_currentInteractable == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                _currentInteractable.Item1.Interact(_character);
            }
        }

        private void OnInteractableEnter(GameObject gameObject)
        {
            if (!gameObject.TryGetComponent(out IInteractable interactable))
                return;
            
            _currentInteractable = Tuple.Create(
                interactable,
                gameObject.GetComponent<InteractionHintView>());
            
            _currentInteractable.Item2.ShowHint();
        }
        private void OnInteractableExit(GameObject obj)
        {
            _currentInteractable.Item2.HideHint();
            
            _currentInteractable = null;
        }
    }
}