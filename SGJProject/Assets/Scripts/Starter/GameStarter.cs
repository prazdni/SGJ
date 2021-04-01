using System;
using Card;
using Controllers;
using UnityEngine;

namespace Starter
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private CardView _cardView;
        private CameraController _cameraController;
        private CardController _cardController;

        private void Awake()
        {
            _cameraController = new CameraController(Camera.main);
            _cardController = new CardController(Camera.main, _cardView, _cameraController);
        }

        private void Update()
        {
            _cameraController.Update(Time.deltaTime);
            //_cardController.Update(Time.deltaTime);
        }
    }
}