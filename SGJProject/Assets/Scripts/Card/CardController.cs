using System;
using Controllers;
using Interface;
using UnityEngine;

namespace Card
{
    public class CardController : IUpdatable
    {
        private Action Action;
        private Camera _camera;
        private Vector3 _defaultPosition;
        private CardView _cardView;
        private float _rotateLerpScale = 3.0f;
        private float _moveLerpScale = 50.0f;

        private bool _isTarget;

        public CardController(Camera camera, CardView cardView, CameraController cameraController)
        {
            _camera = camera;
            _cardView = cardView;
            _defaultPosition = cardView.transform.position;
            cameraController.Action += OnAction;
        }

        public void OnAction(bool isTarget)
        {
            var rotateLerp = _rotateLerpScale * Time.deltaTime;
            var moveLerp = _moveLerpScale * Time.deltaTime;
            
            Vector2 point = _camera.ScreenToViewportPoint(Input.mousePosition);
            point.y = 0.5f;
            var worldPoint = _camera.ViewportToWorldPoint(point);
            worldPoint.z = 0.0f;
            var pos = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.0f, 0.0f));
            
            if (isTarget)
            {
                if (Input.GetMouseButton(0))
                {
                    //SetHorizontal(point.x, ref worldPoint, 0.2f, 0.8f);
                    //SetVertical(point.y, ref worldPoint, 0.4f, 0.6f);
                
                    //var rotationWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
                    //rotationWorldPoint.z = 0.0f;
                    //Vector3 dir = rotationWorldPoint - pos;
                    //float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90.0f;
                    //_cardView.transform.rotation = 
                    //    Quaternion.Lerp(_cardView.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotateLerp);
                
                    _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, worldPoint, moveLerp);
                    //_cardView.transform.position = worldPoint;
                }
                else
                {
                    var posScreen = _camera.WorldToViewportPoint(_cardView.transform.position);
                    if (posScreen.x <= 0.7f && posScreen.x >= 0.3f)
                    {
                        _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, _defaultPosition, moveLerp);
                        _cardView.transform.rotation = Quaternion.Lerp(_cardView.transform.rotation, Quaternion.identity, rotateLerp);
                    }
                }
            }
            else
            {
                var posScreen = _camera.WorldToViewportPoint(_cardView.transform.position);
                if (posScreen.x <= 0.7f && posScreen.x >= 0.3f)
                {
                    _cardView.transform.position = Vector3.Lerp(_cardView.transform.position, _defaultPosition, moveLerp);
                    _cardView.transform.rotation = Quaternion.Lerp(_cardView.transform.rotation, Quaternion.identity, rotateLerp);
                }
            }
        }
        
        private void SetHorizontal(float pointX, ref Vector3 worldPoint, float offsetXLeft, float offsetXRight)
        {
            float newPointX = worldPoint.x;
            
            if (pointX > offsetXRight)
            {
                newPointX = _camera.ViewportToWorldPoint(new Vector3(offsetXRight, 0.0f, 0.0f)).x;
            }

            if (pointX < offsetXLeft)
            {
                newPointX = _camera.ViewportToWorldPoint(new Vector3(offsetXLeft, 0.0f, 0.0f)).x;
            }
            
            worldPoint.x = newPointX;
        }
        
        private void SetVertical(float pointY, ref Vector3 worldPoint, float offsetYLeft, float offsetYRight)
        {
            float newPointY = worldPoint.y;
            
            if (pointY > offsetYRight)
            {
                newPointY = _camera.ViewportToWorldPoint(new Vector3(0.0f, offsetYRight, 0.0f)).y;
            }

            if (pointY < offsetYLeft)
            {
                newPointY = _camera.ViewportToWorldPoint(new Vector3(0.0f, offsetYLeft, 0.0f)).y;
            }

            worldPoint.y = newPointY;
        }

        public void Update(float deltaTime)
        {
            var rotateLerp = _rotateLerpScale * deltaTime;
            var moveLerp = _moveLerpScale * deltaTime;
            
            Vector2 point = _camera.ScreenToViewportPoint(Input.mousePosition);
            point.y = 0.5f;
            var worldPoint = _camera.ViewportToWorldPoint(point);
            worldPoint.z = 0.0f;
            var pos = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.0f, 0.0f));
        }
    }
}