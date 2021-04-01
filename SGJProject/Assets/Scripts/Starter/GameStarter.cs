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
        private CardPool _cardPool;

        private void Awake()
        {
            var cameraMain = Camera.main;
            _cameraController = new CameraController(cameraMain);
            _cardPool = new CardPool(_cardView);
            _cardController = new CardController(cameraMain, _cardView, _cameraController, _cardPool);
            _cardView.Init(_cardController);
        }

        private void Update()
        {
            _cameraController.Update(Time.deltaTime);
            _cardController.Update(Time.deltaTime);
        }
    }
}