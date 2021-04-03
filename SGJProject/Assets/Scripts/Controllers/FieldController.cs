using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Controllers
{
    public class FieldController : MonoBehaviour
    {
        public Action<int> DayChanged = i => { };
        public Action<int> TaskChanged = t => { };
        public int Day => _day;

        public int Tasks => _tasks;

        [SerializeField] private SamplesController _samplesController;
        [SerializeField] private DayController[] _days;
        [SerializeField] private EndGameController _endGameController;

        [SerializeField, Range(0, 10)] private int _day = 0;
        [SerializeField] private int _tasks;

        private bool _isAgent;
        private bool _isDayChanged;
        private bool _isNightCharacter;
        private bool _isMorningCharacter;

        private void Awake()
        {
            _isAgent = false;
            _isNightCharacter = false;
            _isMorningCharacter = false;
            _isDayChanged = false;
            _tasks = 1;
            
            ShowMorningCharacter();
        }

        public void CheckInvisible()
        {
            int quantity = _samplesController.CheckVisibleTasks();
            
            if (quantity == _tasks)
            {
                _isNightCharacter = true;
            }

            if (quantity < _tasks && !_isNightCharacter && !_isMorningCharacter && !_isAgent)
            {
                ChangeDay();
            }

            if (_isAgent)
            {
                _isAgent = false;
                ChangeDay(_day);
            }
            
            if (_isMorningCharacter)
            {
                _isMorningCharacter = false;
                ShowMorningCharacter();
            }
            
            if (_isNightCharacter)
            {
                _isMorningCharacter = true;
                _isNightCharacter = false;
                ShowNightCharacter();
            }
        }
        
        public void ChangeDay()
        {
            _day++;

            if (_day >= _days.Length - 2)
            {
                _endGameController.EndGame("Спасибо за то, что поиграли в игру!");
            }
            else
            {
                ChangeDay(_day);
            }
        }

        private void ChangeTasksQuantity()
        {
            if (_day <= 2)
            {
                _tasks = 1;
            }

            if (2 < _day && _day <= 4)
            {
                _tasks = 3;
            }
        }

        public void ChangeDay(int day)
        {
            _day = day;
            ChangeTasksQuantity();
            
            DayChanged.Invoke(_day);

            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(day));
            
            _days[day].Init(resource);
            
            TaskChanged.Invoke(_samplesController.CheckVisibleTasks() - _tasks);
        }

        public void ShowAgent(Response response)
        {
            _isAgent = true;
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-1));

            _days[_days.Length - 3].Init(resource);
            
            TaskChanged.Invoke(0);
        }

        public void ShowRegular()
        {
            if (_isAgent)
            {
                _isAgent = false;
                ChangeDay(_day);
            }
            else
            {
                if (!_isMorningCharacter)
                {
                    _isMorningCharacter = true;
                    ShowMorningCharacter();
                }
                else
                {
                    if (!_isDayChanged)
                    {
                        _isDayChanged = true;
                        ChangeDay();
                    }
                    else
                    {
                        int quantity = _samplesController.CheckVisibleTasks();
            
                        if (quantity == _tasks)
                        {
                            _isNightCharacter = true;
                            ShowNightCharacter();
                            _isMorningCharacter = false;
                            _isDayChanged = false;
                        }
                    }
                }
            }
        }

        public void ShowNightCharacter()
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-2));
            _days[_days.Length - 1].Init(resource);
            
            TaskChanged.Invoke(0);
            
            _isMorningCharacter = false;
        }

        public void ShowMorningCharacter()
        {
            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-3));
            _days[_days.Length - 2].Init(resource);
            
            TaskChanged.Invoke(0);
        }

        public void RestartDay()
        {
            ChangeDay(_day);
        }

        public void StartTasks()
        {
            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(_day));
            
            _days[_day].Init(resource);
            
            TaskChanged.Invoke(_samplesController.CheckVisibleTasks() - _tasks);
        }

        public void StartDay()
        {
            _day++;
            ChangeTasksQuantity();
            
            DayChanged.Invoke(_day);
            
            ShowMorningCharacter();
        }
    }
}