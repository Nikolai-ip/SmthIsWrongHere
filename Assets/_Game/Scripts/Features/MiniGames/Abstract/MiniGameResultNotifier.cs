using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public abstract class MiniGameResultNotifier : MonoBehaviour
    {
        public abstract event Action<bool> OnResult;
        public UnityEvent<bool> OnResult_UE;
    }
}