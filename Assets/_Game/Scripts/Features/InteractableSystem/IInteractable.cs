using System;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public interface IInteractable
    {
        void Interact(GameObject @this);
    }
    public interface IFocusable
    {
        void Focused();
        void UnFocused();
    }
    public interface IInteractNotifier
    {
        event Action OnInteract;
    }

    public interface IFocusableNotifier
    {
        event Action<bool> OnFocused;
    }
}