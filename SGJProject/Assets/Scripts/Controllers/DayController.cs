using System.Collections.Generic;
using Configs;
using Interface;
using Person;
using UnityEngine;

namespace Controllers
{
    public class DayController : MonoBehaviour, IInitialize<CharactersDaySequence>
    {
        public int Day = 0;
        [SerializeField] private CharacterView[] _characterViews;
        public void Init(CharactersDaySequence item)
        {
            List<Character> characters = new List<Character>(item.Characters);
            
            
            Day = characters.Count;
            
            for (int i = 0; i < Day; i++)
            {
                var num = Random.Range(0, characters.Count);
                var character = characters[num];
                var characterType = character.Characteristics[Random.Range(0, character.Characteristics.Length)];
                
                _characterViews[i].Init(characterType);
                characters.RemoveAt(num);
            }
        }
    }
}