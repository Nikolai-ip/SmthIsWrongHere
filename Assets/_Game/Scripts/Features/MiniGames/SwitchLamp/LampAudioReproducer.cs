using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Common.Utilities;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class LampAudioReproducer:MonoBehaviour
    {
        [SerializeField] private DictionaryInspector<Sounds, List<AudioSource>> _soundsDictionary;

        private Dictionary<Sounds, List<AudioSource>> _audioClips;
        private void Awake()
        {
            _audioClips = _soundsDictionary.GetDictionary();
        }
        public enum Sounds
        {
            NotValidConnection,
            Connecting,
            ConnectOut,
            ValidConnection
        }

        public void PlaySound(Sounds sound) => _audioClips[sound].First().Play();

        public void StopSound(Sounds sound) => _audioClips[sound].First().Stop();

        public void PlayRandomSound(Sounds sound)
        {
            int randomIndex = Random.Range(0, _audioClips[sound].Count);
            _audioClips[sound][randomIndex].Play();
        }
    }
}