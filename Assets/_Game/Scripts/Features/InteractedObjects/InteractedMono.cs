using System;
using _Game.Scripts.Features.InteractableSystem;
using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public abstract class InteractedMono: MonoBehaviour, IInteractable, IInteractNotifier, ISelectable, ISelectNotifier
    {
        public event Action OnInteract;
        public event Action<bool> OnSelect;
        public virtual void Interact(GameObject @this)
        {
            OnInteract?.Invoke();
        }
        public virtual void Select() => OnSelect?.Invoke(true);
        public virtual void Deselect() => OnSelect?.Invoke(false);
    }
}