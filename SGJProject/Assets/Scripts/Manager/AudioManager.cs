using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public static AudioManager Instance;

        private bool _isSilent;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _isSilent = false;
        }

        private void Start()
        {
            AdjustMusicVolume(0.0f);
        }

        public void AdjustMusicVolume(float volume)
        {
            if (!_isSilent)
            {
                _audioMixer.SetFloat("Music", volume);
            }
        }

        public void AdjustMusicVolume()
        {
            _isSilent = !_isSilent;
            
            if (_isSilent)
            {
                _audioMixer.SetFloat("Music", -80.0f);
            }
            else
            {
                _audioMixer.SetFloat("Music", 0.0f);
            }
        }
    }
}