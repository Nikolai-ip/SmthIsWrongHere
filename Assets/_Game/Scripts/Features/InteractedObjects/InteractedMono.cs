using System;
using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public abstract class InteractedMono: MonoBehaviour, IInteractable, IInteractNotifier, IFocusable, IFocusableNotifier
    {
        public event Action OnInteract;
        public event Action<bool> OnFocused;
        public virtual void Interact(GameObject @this)
        {
            OnInteract?.Invoke();
        }
        public virtual void Focused() => OnFocused?.Invoke(true);
        public virtual void UnFocused() => OnFocused?.Invoke(false);
    }
}