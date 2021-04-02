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
        public InfluenceType[] InfluenceTypes;
        public Image Image;
        public Dialogue Dialogues;

        [SerializeField] private TMP_Text _personText;
        
        public void Init(Characteristics item)
        {
            gameObject.SetActive(true);
            
            InfluenceTypes = item.InfluenceTypes;
            Dialogues = item.Dialogue;
            Image.sprite = item.Sprite;
            _personText.text = Dialogues.Phrase;
        }
    }
}