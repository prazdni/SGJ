using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private Transform _pauseMenu;
        [SerializeField] private Button _pauseButton;

        private bool _isEnabled;

        private void Start()
        {
            Time.timeScale = 1.0f;
            
            _pauseButton.onClick.AddListener(SetPause);
            
            _isEnabled = false;
            _pauseMenu.gameObject.SetActive(_isEnabled);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPause();
            }
        }
        
        private void SetPause()
        {
            _isEnabled = !_isEnabled;
            _pauseMenu.gameObject.SetActive(_isEnabled);
                
            if (_isEnabled)
            {
                Time.timeScale = 0.0f;
                AudioManager.Instance.AdjustMusicVolume(-10);
            }
            else
            {
                Time.timeScale = 1.0f;
                AudioManager.Instance.AdjustMusicVolume(0);
            }
        }
        
        public void LoadScene(int sceneNumber)
        {
            if (sceneNumber == 0)
            {
                AudioManager.Instance.AdjustMusicVolume(0);
            }
            
            SceneManager.LoadScene(sceneNumber);
        }
    }
}