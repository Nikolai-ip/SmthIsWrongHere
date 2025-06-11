using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class IDComponent:MonoBehaviour
    {
        [field: SerializeField] public int ID { get; private set; }
    }
}