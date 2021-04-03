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
    public struct Characteristics
    {
        public string Phrase;
        public string Name;
        public string Explanation;
        public List<Response> Responses;
        public Sprite Sprite;
    }

    [Serializable]
    public struct Response
    {
        public string ResponsePhrase;
        public List<Influence> Influences;
    }
    
    [Serializable]
    public struct Influence
    {
        public InfluenceType InfluenceType;
        public float InfluencePoint;
    }
}