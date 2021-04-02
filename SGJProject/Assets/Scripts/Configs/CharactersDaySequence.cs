using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CharacterSequence", menuName = "CharacterSequence", order = 0)]
    public class CharactersDaySequence : ScriptableObject
    {
        public List<Character> Characters;
    }
}