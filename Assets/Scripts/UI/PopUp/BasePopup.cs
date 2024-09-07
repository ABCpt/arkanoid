using GameStates;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.PopUp
{
    public class BasePopup : MonoBehaviour
    {
        [SerializeField] private Button RestartButton;

        protected GameStateService GameStateService;

        [Inject]
        public void Construct(GameStateService gameStateService)
        {
            GameStateService = gameStateService;
        }

        private void Awake()
        {
            GameStateService.ChangeState += OnChangeState;
            gameObject.SetActive(false);
        }
        
        protected virtual void OnEnable()
        {
            RestartButton.onClick.AddListener(OnRestartButton);
        }

        protected virtual void OnDisable()
        {
            RestartButton.onClick.RemoveListener(OnRestartButton);
        }

        private void OnDestroy()
        {
            GameStateService.ChangeState -= OnChangeState;
        }

        private void OnRestartButton()
        {
            GameStateService.SetState<EnterGameState>();
        }

        protected virtual void OnChangeState(BaseGameState gameState)
        {
        }

        protected virtual void Show()
        {
            gameObject.SetActive(true);
        }

        protected virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
