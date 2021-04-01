using Interface;
using MainHero;
using UnityEngine;

namespace Controllers
{
    public class CameraController : IUpdatable
    {
        private readonly CharacterView _characterView;
        private Transform _cameraTransform;

        public CameraController(Camera camera, CharacterView characterView)
        {
            _characterView = characterView;
            _cameraTransform = camera.transform;
        }
        
        public void Update(float deltaTime)
        {
            _cameraTransform.position = _characterView.transform.position.Change(y : 0.0f, z : -10.0f);
        }
    }
}