using System;
using Configs;
using Person;
using UnityEngine;

namespace Controllers
{
    public class SamplesController : MonoBehaviour
    {
        [SerializeField] private CharacterView[] _samples;
        [SerializeField] private AdditionalViewController _additionalViewController;

        private CharacterView _characterView;

        private void Awake()
        {
            foreach (var sample in _samples)
            {
                sample.Button.onClick.AddListener(() => _additionalViewController.ShowAdditional(sample));
                sample.Button.onClick.AddListener(() => _characterView = sample);
            }

            _additionalViewController.Action += OnResponse;
        }

        private void OnResponse(Response response)
        {
            if (response.Influences[0].InfluenceType != InfluenceType.Dialogue && 
                response.Influences[0].InfluenceType != InfluenceType.EndDialogue)
            {
                _characterView.gameObject.SetActive(false);
            }
        }

        public void Cleanup()
        {
            foreach (var sample in _samples)
            {
                sample.gameObject.SetActive(false);
            }
        }

        public int CheckVisibleTasks()
        {
            int visibleCount = 0;

            foreach (var sample in _samples)
            {
                if (sample.gameObject.activeSelf)
                {
                    visibleCount++;
                }
            }

            return visibleCount;
        }
    }
}