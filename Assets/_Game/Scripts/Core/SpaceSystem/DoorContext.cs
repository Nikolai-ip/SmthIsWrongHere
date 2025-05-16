using UnityEngine;

namespace _Game.Scripts.Core.SpaceSystem
{
    public class DoorContext: MonoBehaviour
    {
        [field: SerializeField] public int DoorID { get; private set; }
        [field: SerializeField] public Transform SpawnPlace { get; private set; }
    }
}