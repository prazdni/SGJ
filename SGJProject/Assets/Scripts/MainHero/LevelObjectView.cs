using System;
using UnityEngine;

namespace MainHero
{
    public class LevelObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        
        public Collider2D Collider2D;

        public Rigidbody2D Rigidbody2D;
        
        public Action<LevelObjectView> OnLevelObjectContact = view => { };

        private void OnTriggerEnter2D(Collider2D other)
        {
            var levelObject = other.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact.Invoke(levelObject);
        }
    }
}