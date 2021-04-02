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

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(day));
            _days[day].Init(resource);
        }

        public void ShowAgent(Response response)
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-1));
            
            _days[_days.Length - 1].Init(resource);
        }
    }
}