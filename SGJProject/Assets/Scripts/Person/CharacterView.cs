using Configs;
using Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Person
{
    public class CharacterView : MonoBehaviour, IInitialize<Characteristics>
    {
        public Button Button;
        public Characteristics Characteristics;
        
        [SerializeField] private Image Image;
        [SerializeField] private TMP_Text _personText;
        
        public void Init(Characteristics item)
        {
            gameObject.SetActive(true);
            Characteristics = item;
            Image.sprite = item.Sprite;
            _personText.text = item.Phrase;
        }
    }
}