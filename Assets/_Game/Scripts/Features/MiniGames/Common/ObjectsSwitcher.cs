using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class ObjectsSwitcher:MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        public void SwitchRandomObject()
        {
            SwitchObject(Random.Range(0, _objects.Length));
        }
        private void SwitchObject(int objectIndex)
        {
            foreach (var obj in _objects)
                obj.SetActive(obj == _objects[objectIndex]);
        }
    }
}