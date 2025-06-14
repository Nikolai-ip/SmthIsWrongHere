using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects.UI
{
    public class InteractionHintController: MonoBehaviour
    {
        [SerializeField] private InteractionHintView _interactionHintView;
        private IFocusableNotifier _focusNotifier;
        private void OnEnable()
        {
            _focusNotifier ??= GetComponent<IFocusableNotifier>();
            _focusNotifier.OnFocused += ToggleView;
        }

        private void OnDisable() => _focusNotifier.OnFocused -= ToggleView;

        private void ToggleView(bool onSelect)
        {
            if (onSelect)
                _interactionHintView.ShowHint();
            else
                _interactionHintView.HideHint();
        }
    }
}