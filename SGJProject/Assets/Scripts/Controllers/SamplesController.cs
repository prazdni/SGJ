using System;
using Person;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controllers
{
    public class SamplesController : MonoBehaviour
    {
        [SerializeField] private CharacterView[] _samples;
        [SerializeField] private AdditionalViewController _additionalViewController;

        private void Awake()
        {
            foreach (var sample in _samples)
            {
                sample.Button.onClick.AddListener(() => _additionalViewController.ShowAdditional(sample));
                sample.Button.onClick.AddListener(() => sample.gameObject.SetActive(false));
            }
        }

        public void Cleanup()
        {
            foreach (var sample in _samples)
            {
                sample.gameObject.SetActive(false);
            }
        }

        public int CheckVisible()
        {
            int isVisibleCount = 0;

            foreach (var sample in _samples)
            {
                if (sample.gameObject.activeSelf)
                {
                    isVisibleCount++;
                }
            }

            return isVisibleCount;
        }
    }
}