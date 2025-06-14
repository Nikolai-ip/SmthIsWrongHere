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

        private InteractedMono _interactable;
        
        [TextArea]
        [SerializeField, ReadOnly] private string _debugInteractableName;
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
            if (_interactable == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactable.Interact(_character);
            }
        }

        private void OnInteractableEnter(GameObject gameObj)
        {
            if (!gameObj.TryGetComponent(out InteractedMono interactable)) return;
            if (_interactable == interactable) return;
            
            _interactable?.Deselect();
            _debugInteractableName = "Changed " + interactable.GetType().Name;
            _interactable = interactable;
            _interactable.Select();
        }
        private void OnInteractableExit(GameObject gameObj)
        {
            if (_interactable == null) 
                return;
            _interactable.Deselect();
            _debugInteractableName = "Out of interact range";
            _interactable = null;
        }
    }
}