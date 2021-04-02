using Configs;
using Interface;
using TMPro;
using UnityEngine;

namespace Person
{
    public class CharacterView : MonoBehaviour, IInitialize<Characteristics>
    {
        public InfluenceType[] InfluenceTypes;
        public SpriteRenderer SpriteRenderer;
        public Dialogue Dialogues;

        [SerializeField] private TMP_Text _personText;
        
        public void Init(Characteristics item)
        {
            InfluenceTypes = item.InfluenceTypes;
            Dialogues = item.Dialogue;
            SpriteRenderer.sprite = item.Sprite;
            _personText.text = Dialogues.Phrase;
        }
    }
}