using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class DayTextController : MonoBehaviour
    {
        private Sequence _sequence;
        [SerializeField] private FieldController _fieldController;
        
        private TMP_Text _dayText;
        private AudioSource _audioSource;

        private void Awake()
        {
            _dayText = GetComponent<TMP_Text>();
            _audioSource = GetComponent<AudioSource>();
            
            _sequence = DOTween.Sequence();
            _sequence
                .Append(_dayText.DOFade(1.0f, 1.0f))
                .Append(_dayText.DOFade(0.0f, 1.0f));
            _sequence.SetAutoKill(false);
            
            _fieldController.DayChanged += OnDayChanged;
            _dayText.text = $"";
            
        }

        private void OnDayChanged(int day)
        {
            _audioSource.Play();
            _dayText.text = $"День: {day}";
            _sequence.Restart();
        }
    }
}