using System.Collections.Generic;
using Configs;
using Interface;
using Person;
using UnityEngine;

namespace Controllers
{
    public class DayController : MonoBehaviour, IInitialize<CharactersDaySequence>
    {
        [SerializeField] private CharacterView[] _characterViews;
        
        public void Init(CharactersDaySequence item)
        {
            List<Character> characters = new List<Character>(item.Characters);
            List<CharacterView> characterViews = new List<CharacterView>(_characterViews);
            var quantity = characters.Count;

            for (int i = 0; i < quantity; i++)
            {
                var num1 = Random.Range(0, characters.Count);
                var character = characters[num1];
                var characterType = character.Characteristics[Random.Range(0, character.Characteristics.Count)];

                var num2 = Random.Range(0, characterViews.Count);
                characterViews[num2].Init(characterType);
                characterViews.RemoveAt(num2);
                characters.RemoveAt(num1);
            }
        }
    }
}