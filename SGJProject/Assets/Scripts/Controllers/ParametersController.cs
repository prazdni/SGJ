using Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ParametersController : MonoBehaviour
    {
        [SerializeField] private Image[] _parameters;
        [SerializeField] private FieldController _fieldController;

        private bool _isAgentShown;

        private void Awake()
        {
            foreach (var parameter in _parameters)
            {
                parameter.fillAmount = 0.5f;
            }
        }

        public void ChangeResource(Response response)
        {
            Debug.Log("Changed resource");
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