using System;
using Person;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class Character : ScriptableObject
    {
        public Characteristics[] Characteristics;
    }

    [Serializable]
    public struct Characteristics
    {
        public string Phrase;
        public string Explanation;
        public Response[] Responses;
        public Sprite Sprite;
    }

    [Serializable]
    public struct Response
    {
        public string ResponsePhrase;
        public Influence[] Influences;
    }
    
    [Serializable]
    public struct Influence
    {
        public InfluenceType InfluenceType;
        public float InfluencePoint;
    }
}