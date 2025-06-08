using System;
using UnityEngine;

namespace _Game.Scripts.Core.AudioSystem
{
    [CreateAssetMenu(fileName = "AudioCueEventChanel", menuName = "Audio System/Audio Cue Event Chanel")]
    public class AudioCueEventChanel_SO: ScriptableObject
    {
        public event Action<AudioEventArgs> OnAudioEvent;

        public void RaiseEvent(AudioEventArgs e)
        {
            OnAudioEvent?.Invoke(e);
        }
    }
    
    public class AudioEventArgs: EventArgs
    {
        public AudioEventArgs(string audioName)
        {
            AudioName = audioName;
        }
        public string AudioName { get; }
    }
}