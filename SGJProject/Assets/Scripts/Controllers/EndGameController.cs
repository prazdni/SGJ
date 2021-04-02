using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class EndGameController : MonoBehaviour
    {
        public Action OnRestart = () => { };
        
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private TMP_Text _text;
        
        public void EndGame(string message)
        {
            _text.text = message;
            gameObject.SetActive(true);
        }

        public void Restart()
        {
            OnRestart.Invoke();
            _fieldController.ChangeDay(1);
            gameObject.SetActive(false);
        }

        public void Back()
        {
            SceneManager.LoadScene(0);
        }
    }
}