using Core.Platform.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _health;

        private PlatformModel _platformModel;

        [Inject]
        public void Construct(PlatformModel platformModel)
        {
            _platformModel = platformModel;
            _platformModel.UpdateHealth += OnUpdateHealth;
            OnUpdateHealth();
        }

        private void OnUpdateHealth()
        {
            _health.text = _platformModel.Health.ToString();
        }

        private void OnDestroy()
        {
            _platformModel.UpdateHealth -= OnUpdateHealth;
        }
    }
}
