using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private AudioSource _audioSource;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Debug.Log("CLICK!");
        }
    }
}