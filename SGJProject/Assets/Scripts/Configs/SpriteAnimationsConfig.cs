using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Animations", menuName = "Animations", order = 0)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public AnimState animState;
            public List<Sprite> Sprites = new List<Sprite>();
        }
        public List<SpritesSequence> Sequences = new List<SpritesSequence>();
    }
}