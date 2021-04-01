using System;
using Card;
using Interface;
using UnityEngine;

namespace Controllers
{
    public class CameraController : IUpdatable
    {
        private Camera _camera;
        public Action<bool> Action = (b) => { };

        public CameraController(Camera camera)
        {
            _camera = camera;
        }
        
        public void Update(float deltaTime)
        {
            var raycastHit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (raycastHit.collider && raycastHit.collider.CompareTag("Card") && Input.GetMouseButtonDown(0))
            {
                Action.Invoke(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Action.Invoke(false);
            }
        }
    }
}