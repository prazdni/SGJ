using System;
using Interface;
using TMPro;
using UnityEngine;

namespace Card
{
    public class CardTextView : MonoBehaviour, IInitialize<CardController>
    {
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _text.text = "NotBlah-blah";
        }

        private void OnSet(float item)
        {
            item = Mathf.Abs(item);
            _text.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), 
                item / 0.35f);
            _text.text = "Blah-blah";
        }

        public void Init(CardController item)
        {
            item.Action += OnSet;
        }
    }
}