using Interface;
using MainHero;
using UnityEngine;

namespace Manager
{
    public class PlayerManager : IUpdatableAndFixedUpdatable
    {
        private IUpdatableAndFixedUpdatable _playerPhysicsWalker;

        public PlayerManager(CharacterView view, SpriteAnimator spriteAnimator)
        {
            _playerPhysicsWalker = new PlayerPhysicsWalker(view, spriteAnimator);
        }

        public void Update(float deltaTime)
        {
            _playerPhysicsWalker.Update(deltaTime);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _playerPhysicsWalker.FixedUpdate(fixedDeltaTime);
        }
    }
}