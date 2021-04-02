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

        [SerializeField, Range(0, 10)] private int quantity;
        
        public void Init(CharactersDaySequence item)
        {
            List<Character> characters = new List<Character>(item.Characters);
            List<CharacterView> characterViews = new List<CharacterView>(_characterViews);
            
            for (int i = 0; i < quantity; i++)
            {
                var num1 = Random.Range(0, characters.Count);
                var character = characters[num1];
                var characterType = character.Characteristics[Random.Range(0, character.Characteristics.Length)];

                var num2 = Random.Range(0, characterViews.Count);
                characterViews[num2].Init(characterType);
                characterViews.RemoveAt(num2);
                characters.RemoveAt(num1);
            }
        }

        public void ShowAgent(CharactersDaySequence item, Response response)
        {
            response = ChangeResponse(response);

            List<Character> characters = new List<Character>(item.Characters);
            List<CharacterView> characterViews = new List<CharacterView>(_characterViews);
            
            for (int i = 0; i < quantity; i++)
            {
                var num1 = Random.Range(0, characters.Count);
                var character = characters[num1];
                var characterType = character.Characteristics[Random.Range(0, character.Characteristics.Length)];

                for (int j = 0; j < characterType.Responses.Length; j++)
                {
                    characterType.Responses[i].Influences = response.Influences;
                }
                
                var num2 = Random.Range(0, characterViews.Count);
                characterViews[num2].Init(characterType);
                characterViews.RemoveAt(num2);
                characters.RemoveAt(num1);
            }
        }

        private Response ChangeResponse(Response response)
        {
            for (int i = 0; i < response.Influences.Length; i++)
            {
                var influence = response.Influences[i];
                response.Influences[i] = new Influence
                {
                    InfluenceType = influence.InfluenceType,
                    InfluencePoint = 1
                };
            }

            return response;
        }
    }
}