using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects.UI
{
    public class InteractionHintController: MonoBehaviour
    {
        [SerializeField] private InteractionHintView _interactionHintView;
        private ISelectNotifier _notifier;

        private void OnEnable()
        {
            _notifier ??= GetComponent<ISelectNotifier>();
            _notifier.OnSelect += ToggleView;
        }

        private void OnDisable() => _notifier.OnSelect -= ToggleView;

        private void ToggleView(bool onSelect)
        {
            if (onSelect)
                _interactionHintView.ShowHint();
            else
                _interactionHintView.HideHint();
        }
    }
}