using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _musicButton;
        [SerializeField] private Button _exitButton;

        private bool _shouldSound;
        
        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartClick);
            _musicButton.onClick.AddListener(OnMusicClick);
            _exitButton.onClick.AddListener(OnExitClick);

            _shouldSound = true;
        }

        private void OnStartClick()
        {
            SceneManager.LoadScene(1);
        }

        private void OnMusicClick()
        {
            AudioManager.Instance.AdjustMusicVolume();
        }

        private void OnExitClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}