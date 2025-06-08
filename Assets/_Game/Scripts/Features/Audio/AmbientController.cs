using System;
using _Game.Scripts.Core.AudioSystem;
using UnityEngine;

namespace _Game.Scripts.Features.Audio
{
    public class AmbientController:MonoBehaviour
    {
        [SerializeField] private AudioCueEventChanel_SO _audioCueEventChanel;
        [SerializeField] private string _startAmbientSound;
        private void Start()
        {
            _audioCueEventChanel.RaiseEvent(new AudioEventArgs(_startAmbientSound));
        }
    }
}