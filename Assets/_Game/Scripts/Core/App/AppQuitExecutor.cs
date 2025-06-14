using System;
using UnityEngine;

namespace _Game.Scripts.Core.App
{
    public class AppQuitExecutor: MonoBehaviour
    {
        public event Action OnQuit;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Quit()
        {
            Application.Quit();
            OnQuit?.Invoke();
        }
        
    }
}