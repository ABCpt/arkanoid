using System;
using Core.Player.Model;
using UnityEngine;
using Zenject;

namespace Core.Player.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private PlayerModel _playerModel;
        
        [Inject]
        public void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Awake()
        {
            _spriteRenderer.enabled = false;
        }

        public void OnEnable()
        {
            _playerModel.UpdatePosition += OnUpdatePosition;
            _spriteRenderer.enabled = true;
        }

        public void OnDisable()
        {
            _playerModel.UpdatePosition -= OnUpdatePosition;
            _spriteRenderer.enabled = false;
        }
        
        private void OnUpdatePosition()
        {
            transform.position = _playerModel.Position;
        }
    }
}
