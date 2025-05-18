using UnityEngine;

namespace _Game.Scripts.Test
{
    public class MonoTest:MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera miniGameCamera;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                bool isMainActive = mainCamera.enabled;
                mainCamera.enabled = !isMainActive;
                miniGameCamera.enabled = isMainActive;
            }
        }
    }
}