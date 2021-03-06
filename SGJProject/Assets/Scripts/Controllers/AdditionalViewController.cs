using System;
using Configs;
using Interface;
using Person;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class AdditionalViewController : MonoBehaviour
    {
        public Button AdditionalViewButton;
        public Action<Response> Action = (r) => { };
        
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _literallyWho;
        [SerializeField] private TMP_Text _text;
        
        [SerializeField] private Button _buttonOne;
        [SerializeField] private Button _buttonTwo;
        
        [SerializeField] private TMP_Text _buttonOneText;
        [SerializeField] private TMP_Text _buttonTwoText;

        public void ShowAdditional(CharacterView characterView)
        {
            gameObject.SetActive(true);
            _image.sprite = characterView.Characteristics.Sprite;
            _literallyWho.text = characterView.Characteristics.Name;
            _text.text = characterView.Characteristics.Explanation;
            
            _buttonOne.onClick.RemoveAllListeners();
            _buttonTwo.onClick.RemoveAllListeners();
            
            if (characterView.Characteristics.Responses[0].Influences[0].InfluenceType == InfluenceType.NightCharacter ||
                characterView.Characteristics.Responses[0].Influences[0].InfluenceType == InfluenceType.MorningCharacter ||
                characterView.Characteristics.Responses[0].Influences[0].InfluenceType == InfluenceType.Agent ||
                characterView.Characteristics.Responses[0].Influences[0].InfluenceType == InfluenceType.EndGame)
            {
                _buttonOne.gameObject.SetActive(false);
                _buttonTwo.gameObject.SetActive(true);
                
                _buttonTwo.onClick.AddListener(() => { Action.Invoke(characterView.Characteristics.Responses[0]);});
                _buttonTwoText.text = characterView.Characteristics.Responses[0].ResponsePhrase;
            }
            else
            {
                _buttonOne.gameObject.SetActive(true);
                _buttonTwo.gameObject.SetActive(true);
                
                _buttonOne.onClick.AddListener(() => { Action.Invoke(characterView.Characteristics.Responses[0]);});
                _buttonOneText.text = characterView.Characteristics.Responses[0].ResponsePhrase;
                
                _buttonTwo.onClick.AddListener(() => { Action.Invoke(characterView.Characteristics.Responses[1]);});
                _buttonTwoText.text = characterView.Characteristics.Responses[1].ResponsePhrase;
            }
        }

        public void ShowAdditional(Characteristics characteristics)
        {
            _image.sprite = characteristics.Sprite;
            _literallyWho.text = characteristics.Name;
            _text.text = characteristics.Explanation;
            
            _buttonOne.onClick.RemoveAllListeners();
            _buttonTwo.onClick.RemoveAllListeners();
            
            _buttonTwo.onClick.AddListener(() => { Action.Invoke(characteristics.Responses[0]);});
            _buttonTwoText.text = characteristics.Responses[0].ResponsePhrase;
                
            _buttonOne.gameObject.SetActive(false);
        }
    }
}