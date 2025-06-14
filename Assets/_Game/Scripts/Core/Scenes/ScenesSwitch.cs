using System;
using System.Collections.Generic;
using _Game.Scripts.Common.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Scripts.Core.Scenes
{
    public class ScenesSwitch:MonoBehaviour
    {
        [SerializeField] private DictionaryInspector<SceneType, SceneField> _scenesInspector;
        private Dictionary<SceneType, SceneField> _scenes;
        public void Awake()
        {
            _scenes = _scenesInspector.GetDictionary();
            DontDestroyOnLoad(this);
        }

        public void SwitchScene(SceneType scene)
        {
            SceneManager.LoadScene(_scenes[scene]);
        }

        public void SwitchScene(int scene)
        {
            SwitchScene((SceneType)scene);
        }

    }

    public enum SceneType
    {
        MainMenu,
        Gameplay,
    }
}