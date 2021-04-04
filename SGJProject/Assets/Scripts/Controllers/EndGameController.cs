using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class EndGameController : MonoBehaviour
    {
        public Action OnRestart = () => { };

        [SerializeField] private AudioClip _winAudioClip;
        [SerializeField] private AudioClip _loseAudioClip;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private TMP_Text _text;
        
        public void EndGame(string message, bool isWin)
        {
            _text.text = message;
            _audioSource.clip = isWin ? _winAudioClip : _loseAudioClip;
            _audioSource.Play();
            gameObject.SetActive(true);
        }

        public void Restart()
        {
            OnRestart.Invoke();
            gameObject.SetActive(false);
        }

        public void Back()
        {
            SceneManager.LoadScene(0);
        }
    }
}