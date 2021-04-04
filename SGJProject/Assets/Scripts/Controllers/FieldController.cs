using System;
using Configs;
using UnityEngine;

namespace Controllers
{
    public class FieldController : MonoBehaviour
    {
        public Action<int> DayChanged = i => { };
        public Action<int> TaskChanged = t => { };

        [SerializeField] private DialogueViewController _dialogueViewController;
        [SerializeField] private SamplesController _samplesController;
        [SerializeField] private DayController[] _days;
        [SerializeField] private EndGameController _endGameController;

        [SerializeField, Range(0, 10)] private int _day = 0;
        [SerializeField] private int _tasks;

        private void Awake()
        {
            _tasks = 1;
            
            ShowStartDialogue();

            _endGameController.OnRestart += OnRestart;
        }

        private void OnRestart()
        {
            _dialogueViewController.CleanupDialogue();

            _day = 1;
            
            RestartDay();
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
            if (_day <= 3)
            {
                Debug.Log("first " + _day);
                _tasks = 1;
            }

            if (3 < _day && _day <= 7)
            {
                Debug.Log("second " + _day);
                _tasks = 1;
            }

            if (7 < _day && _day <= 10)
            {
                Debug.Log("third " + _day);
                _tasks = 1;
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
            
            if (_day == 11)
            {
                ShowGoodEnding();
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

        public void EndGame(string str, bool isWin)
        {
            _samplesController.Cleanup();
            _endGameController.EndGame(str, isWin);
        }

        private void ShowStartDialogue()
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<Character>(Extensions.Return(InfluenceType.Dialogue));
            _days[2].Init(resource.Characteristics[0]);
            _dialogueViewController.SetDialogue(resource);
        }

        public void ChangeDialogue()
        {
            _dialogueViewController.ChangeDialogueScene();
        }

        public void EndDialogue()
        {
            _dialogueViewController.CleanupDialogue();
            StartDay();
        }

        public void ShowBadEnding(InfluenceType type, bool isBottom)
        {
            _samplesController.Cleanup();
            
            var resource = Resources.Load<CharactersDaySequence>(Extensions.Return(type, isBottom));
            _days[1].Init(resource);
            TaskChanged.Invoke(0);
        }

        public void ShowGoodEnding()
        {
            _samplesController.Cleanup();
            var resource = Resources.Load<Character>(Extensions.Return(-5));
            Debug.Log(resource.Characteristics[0].Phrase);
            _days[2].Init(resource.Characteristics[0]);
            _dialogueViewController.SetDialogue(resource);
        }
    }
}