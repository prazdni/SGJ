using DG.Tweening;
using UnityEngine;

namespace Card
{
    public class CardPool
    {
        public bool IsAnimation => _sequence.IsPlaying();
        private readonly CardView _cardView;
        private Sequence _sequence;
        private Vector3 _startPosition;
        private Vector3 _startScale;

        public CardPool(CardView cardView)
        {
            _cardView = cardView;
            _startPosition = _cardView.transform.position;
            _startScale = _cardView.transform.localScale;
            
            _sequence = DOTween.Sequence();
            
            _sequence.Append(_cardView.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 1.0f))
                .Append(_cardView.transform.DOMove(_startPosition, 0.0001f))
                .Join(_cardView.transform.DOScale(_startScale, 0.0001f))
                .Append(_cardView.transform.DORotate(new Vector3(0, 180, 0), 0.01f))
                .Append(_cardView.transform.DORotate(new Vector3(0, 0, 0), 1.0f));
            _sequence.Pause();
            _sequence.SetAutoKill(false);
            
            _sequence.onComplete += OnComplete;
        }
        public void ReturnToPool()
        {
            _sequence.Restart();
            _sequence.Play();
        }

        private void OnComplete()
        {
            _sequence.Pause();
        }
    }
}