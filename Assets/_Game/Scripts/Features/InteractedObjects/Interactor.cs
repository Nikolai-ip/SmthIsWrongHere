using System;
using _Game.Scripts.Core.Triggers;
using _Game.Scripts.Features.InteractableSystem;
using Tools.DevTools;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private BaseTrigger _trigger;

        private Tuple<IInteractable, InteractionHintView> _currentInteractable;
        [TextArea]
        [SerializeField, ReadOnly] private string _currentInteractableName;
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
            _currentInteractableName = interactable.GetType().Name;
            _currentInteractable.Item2.ShowHint();
        }
        private void OnInteractableExit(GameObject obj)
        {
            if (_currentInteractable == null) 
                return;
            _currentInteractable.Item2.HideHint();
            _currentInteractableName = "";
            _currentInteractable = null;
        }
    }
}