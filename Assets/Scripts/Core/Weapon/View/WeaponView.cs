using Core.Platform.Model;
using Core.Weapon.Model;
using UnityEngine;
using Zenject;

namespace Core.Weapon.View
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private WeaponModel _weaponModel;
        
        [Inject]
        public void Construct(WeaponModel weaponModel)
        {
            _weaponModel = weaponModel;
        }

        public void Awake()
        {
            _spriteRenderer.enabled = false;
        }

        public void OnEnable()
        {
            _spriteRenderer.enabled = false;
            _weaponModel.Attack += OnAttack;
            _weaponModel.Charge += OnCharge;
        }
        
        public void OnDisable()
        {
            _weaponModel.Attack -= OnAttack;
            _weaponModel.Charge -= OnCharge;
        }

        private void OnAttack(Vector2 direction)
        {
            _spriteRenderer.enabled = false;
        }
        
        private void OnCharge()
        {
            _spriteRenderer.enabled = true;
        }
    }
}
