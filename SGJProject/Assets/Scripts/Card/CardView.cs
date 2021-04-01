using System;
using Interface;
using UnityEngine;

namespace Card
{
    public class CardView : MonoBehaviour, IInitialize<CardController>
    {
        [SerializeField] private CardTextView _cardTextView;
        
        public void Init(CardController item)
        {
            _cardTextView.Init(item);
        }
    }
}