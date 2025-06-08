using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.Audio
{
    public class InteractObjectAudioSource:MonoBehaviour
    {
        private IInteractNotifier _interactNotifier;
        [SerializeField] private AudioSource _interactSound;

        private void OnValidate()
        {
            if (!TryGetComponent(out IInteractNotifier interactNotifier))
                Debug.LogError("Failed to attack interact notifier");
        }
        private void OnEnable()
        {
            _interactNotifier ??= GetComponent<IInteractNotifier>();
            _interactNotifier.OnInteract += PlayInteractSound;
        }
        private void OnDisable()
        {
            if (_interactNotifier != null)
                _interactNotifier.OnInteract -= PlayInteractSound;
        }

        private void PlayInteractSound()
        {
            _interactSound.Play();
        }
    }
}