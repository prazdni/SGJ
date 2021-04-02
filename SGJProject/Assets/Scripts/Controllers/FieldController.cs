using System;
using Configs;
using UnityEngine;

namespace Controllers
{
    public class FieldController : MonoBehaviour
    {
        [SerializeField] private SamplesController _samplesController;
        [SerializeField] private DayController[] _days;
        
        public int Day = 0;
        public Action<int> DayChanged = i => { };

        private void Awake()
        {
            ChangeDay(Day);
        }

        public void ChangeDay()
        {
            Day++;
            ChangeDay(Day);
            DayChanged.Invoke(Day);
        }

        private void ChangeDay(int day)
        {
            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.ReturnDay(day));
            _days[day].Init(resource);
        }
    }
}