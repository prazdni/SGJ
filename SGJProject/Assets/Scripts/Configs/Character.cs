using System;
using System.Collections.Generic;
using Person;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class Character : ScriptableObject
    {
        public List<Characteristics> Characteristics;
    }

    [Serializable]
    public class Characteristics
    {
        public string Phrase;
        public string Explanation;
        public List<Response> Responses;
        public Sprite Sprite;
    }

    [Serializable]
    public class Response
    {
        public string ResponsePhrase;
        public List<Influence> Influences;
    }
    
    [Serializable]
    public class Influence
    {
        public InfluenceType InfluenceType;
        public float InfluencePoint;
    }
}