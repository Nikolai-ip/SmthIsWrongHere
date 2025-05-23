using UnityEngine;

namespace _Game.Scripts.Core.DayProgressionSystem.DayEventInitializers
{
    public abstract class DayEventыInitializer : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void UnInitialize();
    }
}