using System;
using UnityEngine;

namespace _Game.Scripts.Features.InteractableSystem
{
    public interface IInteractable
    {
        void Interact(GameObject @this);
    }

    public interface IInteractNotifier
    {
        event Action OnInteract;
    }
}