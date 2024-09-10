using System;
using Core.Platform.Model;
using UnityEngine;
using Zenject;

namespace Core.Platform.View
{
    public class PlatformView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private PlatformModel _platformModel;
        
        [Inject]
        public void Construct(PlatformModel platformModel)
        {
            _platformModel = platformModel;
        }

        public void Awake()
        {
            _spriteRenderer.enabled = false;
        }

        public void OnEnable()
        {
            _platformModel.UpdatePosition += OnUpdatePosition;
            _spriteRenderer.enabled = true;
        }

        public void OnDisable()
        {
            _platformModel.UpdatePosition -= OnUpdatePosition;
            _spriteRenderer.enabled = false;
        }
        
        private void OnUpdatePosition()
        {
            transform.position = _platformModel.Position;
        }
    }
}
