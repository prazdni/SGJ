using Configs;
using Interface;
using UnityEngine;

namespace MainHero
{
    public class PlayerPhysicsWalker : IUpdatableAndFixedUpdatable
    {
        private const string _verticalAxisName = "Vertical";
        private const string _horizontalAxisName = "Horizontal";
        
        private const float _animationsSpeed = 40.0f;
        private const float _walkSpeed = 250.0f;
        private const float _jumpForce = 8.0f;
        private const float _jumpThresh = 0.1f;
        private const float _flyThresh = 1.0f;
        private const float _movingThresh = 0.1f;

        private bool _doJump;
        private float _goSideWay;

        private LevelObjectView _view;
        private readonly SpriteAnimator _spriteAnimator;
        private ContactsPoller _contactsPoller;
        private bool _doCrawl;

        public PlayerPhysicsWalker(LevelObjectView character, SpriteAnimator animator)
        {
            _view = character;
            _spriteAnimator = animator;
            _contactsPoller = new ContactsPoller(character.Collider2D);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _doJump = Input.GetAxis(_verticalAxisName) > 0;
            _doCrawl = Input.GetAxis(_verticalAxisName) < 0;
            _goSideWay = Input.GetAxis(_horizontalAxisName);
            _contactsPoller.Update(fixedDeltaTime);

            var walks = Mathf.Abs(_goSideWay) > _movingThresh;

            if (walks)
            {
                _view.SpriteRenderer.flipX = _goSideWay < 0;
            }

            var newVelocity = 0.0f;

            if (walks && (_goSideWay > 0 || !_contactsPoller.HasLeftContacts) &&
                (_goSideWay < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = fixedDeltaTime * (_goSideWay < 0 ? -1 : 1) *
                              (_walkSpeed);
            }

            _view.Rigidbody2D.velocity =
                _view.Rigidbody2D.velocity.Change(newVelocity +
                                                  (_contactsPoller.IsGrounded ? _contactsPoller.GroundVelocity.x : 0));
            
            _view.gameObject.layer = 0;
            if (_contactsPoller.IsGrounded && _doJump &&
                Mathf.Abs(_view.Rigidbody2D.velocity.y - _contactsPoller.GroundVelocity.y) <= _jumpThresh)
            {
                _view.Rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            }

            if (_contactsPoller.IsGrounded)
            {
                var track = walks ? AnimState.Walk : AnimState.Idle;
                Debug.Log(track);
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, track, true, _animationsSpeed);
            }
            else 
            {
                //if (_view.Rigidbody2D.velocity.y > _flyThresh)
                //{
                //    _spriteAnimator.StartAnimation(_view.SpriteRenderer, AnimState.JumpUp, true, _animationsSpeed);
                //}
                //else if (_view.Rigidbody2D.velocity.y < -_flyThresh)
                //{
                //    _spriteAnimator.StartAnimation(_view.SpriteRenderer, AnimState.JumpDown, true, _animationsSpeed);
                //}
            }
        }

        public void Update(float deltaTime)
        {
            _spriteAnimator.Update(deltaTime);
        }
    }

}