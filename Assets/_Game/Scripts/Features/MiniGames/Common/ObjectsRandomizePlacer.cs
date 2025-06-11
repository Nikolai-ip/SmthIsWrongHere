using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.Common
{
    public class ObjectsRandomizePlacer:MonoBehaviour
    {
        [SerializeField] private GameObject[] _gameObjects;
        [SerializeField] private Transform[] _places;

        public void PlaceObjects()
        {
            if (_gameObjects.Length != _places.Length)
            {
                Debug.LogError("Failed to place objects: Lengths in collections aren't equal");
                return;
            }

            List<int> accum = new();
            for (int i = 0; i < _places.Length; i++)
            {
                int randomIndex = 0;
                do
                {
                    randomIndex = Random.Range(0, _places.Length);
                } while (accum.Contains(randomIndex));
                accum.Add(randomIndex);
                _gameObjects[randomIndex].transform.position = _places[i].position;
            }
            
        }
    }
}