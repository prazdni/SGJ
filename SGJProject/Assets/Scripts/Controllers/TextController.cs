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
            _dayText.text = "";
            _taskText.text = "";
        }

        private void OnDayChanged(int day)
        {
            _dayText.text = $"День: {day}";
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
                    _taskText.text = $"Заданий сделать: {Mathf.Clamp(task, 0, 10)}";
                }
            }
        }
    }
}