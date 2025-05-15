using UnityEngine;

namespace _Game.Scripts.Common.Utilities
{
    public class CollisionValidator
    {
        public bool IsValid(GameObject other, LayerMask validLayerMasks)
        {
            int otherLayer = other.layer;
            bool result = (validLayerMasks.value & (1 << otherLayer)) != 0;
            return result;
        }
    }
}