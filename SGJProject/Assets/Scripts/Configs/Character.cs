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
        public InfluenceType[] InfluenceTypes;
        public float InfluencePoint;
        public Dialogue Dialogue;
        public Sprite Sprite;
    }

    [Serializable]
    public struct Dialogue
    {
        public string Phrase;
        public string PositiveResponse;
        public string NegativeResponse;
    }
}