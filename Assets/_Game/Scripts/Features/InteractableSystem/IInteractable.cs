using System;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public interface IInteractable
    {
        void Interact(GameObject @this);
    }
    public interface ISelectable
    {
        void Select();
        void Deselect();
    }
    public interface IInteractNotifier
    {
        event Action OnInteract;
    }

    public interface ISelectNotifier
    {
        event Action<bool> OnSelect;
    }
}