using System;
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

        private void Awake()
        {
            _tasks = 1;
            
            ShowMorningCharacter();
        }

        public void Check()
        {
            int quantity = _samplesController.CheckVisibleTasks();

            if (quantity == _tasks)
            {
                ShowNightCharacter();
            }
            
            TaskChanged.Invoke(quantity - _tasks);
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
            
            _days[0].Init(resource);
            
            TaskChanged.Invoke(_samplesController.CheckVisibleTasks() - _tasks);
        }

        public void ShowAgent(Response response)
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-1));
            _days[1].Init(resource);
            
            TaskChanged.Invoke(0);
        }

        public void ShowNightCharacter()
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-2));
            _days[1].Init(resource);
            
            TaskChanged.Invoke(0);
        }

        public void ShowEndGameCharacter()
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-4));
            _days[1].Init(resource);
            
            TaskChanged.Invoke(0);
        }

        public void ShowMorningCharacter()
        {
            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(-3));
            
            if (_day == 2)
            {
                ShowEndGameCharacter();
            }
            else
            {
                _days[1].Init(resource);
            }

            TaskChanged.Invoke(0);
        }

        public void RestartDay()
        {
            Debug.Log(_day);
            ChangeDay(_day);
        }

        public void StartTasks()
        {
            _samplesController.Cleanup();

            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(_day));
            
            _days[0].Init(resource);
            
            TaskChanged.Invoke(_samplesController.CheckVisibleTasks() - _tasks);
        }

        public void StartDay()
        {
            _day++;
            
            DayChanged.Invoke(_day);
            ChangeTasksQuantity();
            ShowMorningCharacter();
        }

        public void EndGame(string str)
        {
            _samplesController.Cleanup();
            _endGameController.EndGame(str);
        }
    }
}