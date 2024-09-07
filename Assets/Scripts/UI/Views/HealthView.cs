using Core.Player.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _health;

        private PlayerModel _playerModel;

        [Inject]
        public void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerModel.UpdateHealth += OnUpdateHealth;
            OnUpdateHealth();
        }

        private void OnUpdateHealth()
        {
            _health.text = _playerModel.Health.ToString();
        }

        private void OnDestroy()
        {
            _playerModel.UpdateHealth -= OnUpdateHealth;
        }
    }
}
