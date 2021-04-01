using System;
using System.Collections.Generic;
using Configs;
using Interface;
using MainHero;
using UnityEngine;

namespace Animation
{
    public class DefaultAnimation : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _levelObjectView;
        [SerializeField] private SpriteAnimationsConfig _config;
        private List<IAnimatable<SpriteRenderer>> _defaultAnimations;
        private IAnimatable<SpriteRenderer> _defaultAnimation;

        private void Awake()
        {
            StartAnimation(_levelObjectView.SpriteRenderer, AnimState.Idle, true, 10);
        }

        private void Update()
        {
            //foreach (var defaultAnimation in _defaultAnimations)
            //{
            //    defaultAnimation.Update(Time.deltaTime);
            //}
            
            _defaultAnimation.Update(Time.deltaTime);
        }

        private void StartAnimation(SpriteRenderer spriteRenderer, AnimState animState, bool loop, float speed)
        {
            _defaultAnimation = new SpriteAnimator(_config);
            _defaultAnimation.StartAnimation(spriteRenderer, animState, loop, speed);
        }

        public void StartAnimation(List<SpriteRenderer> spriteRenderer, AnimState animState, bool loop, float speed)
        {
            _defaultAnimations = new List<IAnimatable<SpriteRenderer>>();
            foreach (var w in spriteRenderer)
            {
                _defaultAnimations.Add(new SpriteAnimator(_config));
            }

            for (int i = 0; i < _defaultAnimations.Count; i++)
            {
                _defaultAnimations[i].StartAnimation(spriteRenderer[i], AnimState.Idle, true, 10);
            }
        }

        public void StopAnimation(List<SpriteRenderer> sprite)
        {
            for (int i = 0; i < sprite.Count; i++)
            {
                _defaultAnimations[i].StopAnimation(sprite[i]);
            }
        }
        
        public void StopAnimation(SpriteRenderer sprite)
        {
            _defaultAnimation.StopAnimation(sprite);
        }
    }
}