using System;
using Configs;
using Controllers;
using MainHero;
using Manager;
using UnityEngine;

namespace Starter
{
    public class MainSceneStarter : MonoBehaviour
    {
        [SerializeField] private CharacterView _player;
        private SpriteAnimationsConfig _config;
        private SpriteAnimator _spriteAnimator;
        private PlayerPhysicsWalker _playerPhysicsWalker;
        
        private PlayerManager _playerManager;
        private CameraController _cameraController;

        private void Start()
        {
            _playerManager = new PlayerManager(_player, new SpriteAnimator(Resources.Load<SpriteAnimationsConfig>("PlayerAnimationsConfig")));
            _cameraController = new CameraController(Camera.main, _player);
        }

        private void Update()
        {
            _playerManager.Update(Time.deltaTime);
            _cameraController.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _playerManager.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}