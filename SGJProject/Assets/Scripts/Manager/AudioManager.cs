using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public static AudioManager Instance;

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
        }

        private void Start()
        {
            AdjustMusicVolume(0.0f);
        }

        public void AdjustMusicVolume(float volume)
        {
            _audioMixer.SetFloat("Music", volume);
        }

        public void AdjustMusicVolume(bool shouldSound)
        {
            if (shouldSound)
            {
                _audioMixer.SetFloat("Music", 0.0f);
            }
            else
            {
                _audioMixer.SetFloat("Music", -80.0f);
            }
        }
    }
}