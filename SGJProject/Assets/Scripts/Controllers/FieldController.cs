using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Controllers
{
    public class FieldController : MonoBehaviour
    {
        [SerializeField] private SamplesController _samplesController;
        [SerializeField] private DayController[] _days;
        [SerializeField] private EndGameController _endGameController;
        [SerializeField] private DayController _agentController;

        [SerializeField, Range(0, 10)] private int Day = 0;
        public Action<int> DayChanged = i => { };

        private bool _isAgent;

        private void Awake()
        {
            _isAgent = false;
            ChangeDay(Day);
        }

        public void CheckVisible()
        {
            int quantity = _samplesController.CheckVisible();

            if (quantity == 0)
            {
                if (_isAgent)
                {
                    _isAgent = false;
                    ChangeDay(Day);
                }
                else
                {
                    ChangeDay();
                }
            }
        }
        
        public void ChangeDay()
        {
            Day++;
            
            if (Day >= _days.Length)
            {
                _endGameController.EndGame("Спасибо за то, что поиграли в игру!");
            }
            else
            {
                ChangeDay(Day);
                DayChanged.Invoke(Day);
            }
        }

        public void ChangeDay(int day)
        {
            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(day));
            _days[day].Init(resource);
        }

        public void ShowAgent(Response response)
        {
            _isAgent = true;
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-1));

            //for (int i = 0; i < response.Influences.Count; i++)
            //{
            //    response.Influences[i].InfluencePoint = 0.5f;
            //}
            //
            //for (int i = 0; i < resource.Characters.Count; i++)
            //{
            //    for (int j = 0; j < resource.Characters[i].Characteristics.Count; j++)
            //    {
            //        for (int k = 0; k < resource.Characters[i].Characteristics[j].Responses.Count; k++)
            //        {
            //            resource.Characters[i].Characteristics[j].Responses[k].Influences = response.Influences;
            //        }
            //    }
            //}
            
            _days[_days.Length - 1].Init(resource);
        }
    }
}