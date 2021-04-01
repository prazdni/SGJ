using System;
using Controllers;
using Interface;
using UnityEngine;

namespace Card
{
    public class CardController : IUpdatable
    {
        public Action<float> Action = (f) => { };
        private Camera _camera;
        private Vector3 _defaultPosition;
        private CardView _cardView;
        private readonly CardPool _cardPool;

        private float _moveLerpScale = 15.0f;

        private bool _isTarget;

        public CardController(Camera camera, CardView cardView, CameraController cameraController, CardPool cardPool)
        {
            _camera = camera;
            _cardView = cardView;
            _cardPool = cardPool;
            _defaultPosition = cardView.transform.position;
            cameraController.Action += OnAction;
        }

        private void OnAction(bool isTarget)
        {
            _isTarget = isTarget;
        }

        public void Update(float deltaTime)
        {
            if (!_cardPool.IsAnimation)
            {
                var moveLerp = _moveLerpScale * deltaTime;
            
                Vector2 point = _camera.ScreenToViewportPoint(Input.mousePosition);
                point.y = 0.5f;
            
                var cardViewportPoint = _camera.WorldToViewportPoint(_cardView.transform.position);
                cardViewportPoint.z = 0.0f;
            
                var worldPoint = _camera.ViewportToWorldPoint(point);
                worldPoint.z = 0.0f;

                if (_isTarget)
                {
                    var posScreenRight = _camera.ViewportToWorldPoint(new Vector3(0.85f, 0.5f, 0.0f));
                    posScreenRight.z = 0.0f;
                    var posScreenLeft = _camera.ViewportToWorldPoint(new Vector3(0.15f, 0.5f, 0.0f));
                    posScreenLeft.z = 0.0f;
                
                    Action.Invoke(cardViewportPoint.x - 0.5f);
                
                    if (point.x >= 0.7f)
                    {
                        _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, posScreenRight, moveLerp);
                    }

                    if (point.x <= 0.3f)
                    {
                        _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, posScreenLeft, moveLerp);
                    }

                    if (point.x < 0.7f && point.x > 0.3f)
                    {
                        _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, worldPoint, moveLerp);
                    }
                }
                else
                {
                
                    if (point.x >= 0.7f)
                    {
                        _cardPool.ReturnToPool();
                        Action.Invoke(0.0f);
                    }
                    else
                    {
                        _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, _defaultPosition, moveLerp);
                    }
                }
            }
        }
    }
}