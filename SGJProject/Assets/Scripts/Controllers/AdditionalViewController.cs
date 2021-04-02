using System;
using Person;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class AdditionalViewController : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_Text _buttonOneText;
        [SerializeField] private TMP_Text _buttonTwoText;
        
        public void ShowAdditional(CharacterView characterView)
        {
            gameObject.SetActive(true);
            _image.sprite = characterView.Image.sprite;
            _text.text = characterView.Dialogues.Explanation;
            _buttonOneText.text = characterView.Dialogues.PositiveResponse;
            _buttonTwoText.text = characterView.Dialogues.NegativeResponse;
            
            Debug.Log(characterView.Dialogues.Phrase);
        }
    }
}