using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Core.FileSystem;
using UnityEngine;

namespace _Game.Scripts.Core.AudioSystem
{
    public class AmbientService:MonoBehaviour
    {
        private Dictionary<string, AudioClip> _ambients = new();
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioCueEventChanel_SO _audioCue;
        private void Awake()
        {
            var ambients = Resources.LoadAll<AudioClip>(Path.AmbientDirectory).ToList();
            _ambients = ambients.ToDictionary(ambient => ambient.name, ambient => ambient);
        }

        private void OnEnable()
        {
            _audioCue.OnAudioEvent += SwitchAmbient;
        }

        private void SwitchAmbient(AudioEventArgs eventArgs)
        {
            if (_ambients.TryGetValue(eventArgs.AudioName, out AudioClip clip))
            {
                _audioSource.Stop();
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
        private void OnDisable()
        {
            _audioCue.OnAudioEvent -= SwitchAmbient;
        }
    }
}