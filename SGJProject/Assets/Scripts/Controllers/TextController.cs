using System;
using Interface;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class TextController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        
        [SerializeField] private TMP_Text _dayText;
        [SerializeField] private TMP_Text _taskText;

        private void Awake()
        {
            _fieldController.DayChanged += OnDayChanged;
            _fieldController.TaskChanged += OnTaskChanged;
            _dayText.text = $"день: 1";
            _taskText.text = $"заданий сделать: 1";
        }

        private void OnDayChanged(int day)
        {
            _dayText.text = $"день: {day}";
        }

        private void OnTaskChanged(int task)
        {
            if (task == 0)
            {
                _taskText.text = "";
            }
            else
            {
                if (Mathf.Clamp(task, 0, 10) == 0)
                {
                    _taskText.text = "";
                }
                else
                {
                    _taskText.text = $"заданий сделать: {Mathf.Clamp(task, 0, 10)}";
                }
            }
        }
    }
}