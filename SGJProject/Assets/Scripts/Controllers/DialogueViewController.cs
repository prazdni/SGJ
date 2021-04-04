using System;
using System.Collections.Generic;
using Configs;
using Person;
using UnityEngine;

namespace Controllers
{
    public class DialogueViewController : MonoBehaviour
    {
        [SerializeField] private CharacterView _dialogueCharacterView;
        [SerializeField] private AdditionalViewController _additionalViewController;
        private List<Characteristics> _characteristics;

        private int _characteristicsCount = 0;

        private void Awake()
        {
            _dialogueCharacterView.Button.onClick
                .AddListener(() => _additionalViewController.gameObject.SetActive(true));
        }

        public void SetDialogue(Character characterDialogue)
        {
            _characteristicsCount = 0;
            _dialogueCharacterView.gameObject.SetActive(true);
            _characteristics = characterDialogue.Characteristics;
            _additionalViewController.ShowAdditional(_characteristics[_characteristicsCount]);
        }

        public void ChangeDialogueScene()
        {
            _characteristicsCount++;
            _additionalViewController.ShowAdditional(_characteristics[_characteristicsCount]);
        }

        public void CleanupDialogue()
        {
            _dialogueCharacterView.gameObject.SetActive(false);
        }
    }
}