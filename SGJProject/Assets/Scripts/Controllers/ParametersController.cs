using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ParametersController : MonoBehaviour
    {
        [SerializeField] private Image[] _parameters;
        
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private AdditionalViewController _additionalViewController;
        [SerializeField] private EndGameController _endGameController;

        private List<float> _previousValue;
        private bool _isAgentShown;

        private void Awake()
        {
            SetParameters();

            _additionalViewController.Action += ChangeResource;
            _endGameController.OnRestart += SetParameters;

            _previousValue = new List<float>();
        }

        private void SetParameters()
        {
            foreach (var parameter in _parameters)
            {
                parameter.fillAmount = 0.5f;
            }
            
            _isAgentShown = false;
        }

        public void ChangeResource(Response response)
        {
            _additionalViewController.gameObject.SetActive(false);

            var influences = response.Influences;

            var previousValue = new List<float>();
            for (int i = 0; i < _parameters.Length; i++)
            {
                previousValue.Add(_parameters[i].fillAmount);
            }
            
            foreach (var influence in influences)
            {
                var type = influence.InfluenceType;

                switch (type)
                {
                    case InfluenceType.None:
                        break;
                    case InfluenceType.Money:
                        _parameters[0].fillAmount = _parameters[0].fillAmount + influence.InfluencePoint;
                        break;
                    case InfluenceType.Science:
                        _parameters[1].fillAmount = _parameters[1].fillAmount + influence.InfluencePoint;
                        break;
                    case InfluenceType.Awards:
                        _parameters[2].fillAmount = _parameters[2].fillAmount + influence.InfluencePoint;
                        break;
                    case InfluenceType.Tools:
                        _parameters[3].fillAmount = _parameters[3].fillAmount + influence.InfluencePoint;
                        break;
                    case InfluenceType.Revert:
                        for (int i = 0; i < _parameters.Length; i++)
                        {
                            _parameters[i].fillAmount = _previousValue[i];
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var tuple = CheckDeath();
            
            if (tuple.index != -1)
            {
                if (!_isAgentShown)
                {
                    _previousValue = new List<float>(previousValue);
                    _isAgentShown = true;
                    ShowAgent(response);
                }
                else
                {
                    _endGameController.EndGame("");
                }
            }
            else
            {
                _fieldController.CheckInvisible();
            }
        }

        private (int index, bool isBottom) CheckDeath()
        {
            var index = -1;
            var isBottom = false;
            
            for (int i = 0; i < _parameters.Length; i++)
            {
                if (_parameters[i].fillAmount == 0.0f)
                {
                    index = i;
                    isBottom = true;
                    break;
                }

                if (_parameters[i].fillAmount == 1.0f)
                {
                    index = i;
                    isBottom = false;
                }
            }

            return (index, isBottom);
        }

        private void ShowAgent(Response response)
        {
            _fieldController.ShowAgent(response);
            
            _isAgentShown = true;
        }
    }
}