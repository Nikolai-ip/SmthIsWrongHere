using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class MiniGameOpener : BaseAction
    {
        public override void Perform()
        {
            if (IsPerforming)
                return;
            
            IsPerforming = true;
            Debug.Log("Interact!");
            IsPerforming = false;
        }
    }
}