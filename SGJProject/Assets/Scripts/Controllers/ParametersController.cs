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

        private bool _isAgentShown;

        private void Awake()
        {
            foreach (var parameter in _parameters)
            {
                parameter.fillAmount = 0.5f;
            }

            _additionalViewController.Action += ChangeResource;
        }

        public void ChangeResource(Response response)
        {
            _additionalViewController.gameObject.SetActive(false);
            _fieldController.CheckVisible();
        }

        private void ShowAgent(Response response)
        {
            if (!_isAgentShown)
            {
                _fieldController.ShowAgent(response);
            }
            
            _isAgentShown = true;
        }

        public void SetDefault()
        {
            foreach (var parameter in _parameters)
            {
                parameter.fillAmount = 0.5f;
            }
        }
    }
}