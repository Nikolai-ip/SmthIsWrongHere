using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public abstract class BaseAction : MonoBehaviour
    {
        public bool IsPerforming { get; protected set; }
        public abstract bool CanPerform { get; }

        public abstract void Perform();
        public abstract void UnPerform();
    }
}