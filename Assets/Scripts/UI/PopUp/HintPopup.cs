using System;
using System.Threading.Tasks;
using Core.Level.Model;
using GameStates;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.PopUp
{
   public class HintPopup : BasePopup
   {
      [SerializeField] private Button _startButton;

      private const float DelayBeforeUnpauseSeconds = 0.25f;
      private LevelModel _levelModel;
      
      [Inject]
      public void Construct(LevelModel levelModel)
      {
         _levelModel = levelModel;
      }
      
      protected override void OnChangeState(BaseGameState gameState)
      {
         if (gameState is EnterGameState)
            Show();
         else
            Hide();
      }

      protected override void OnEnable()
      {
         _startButton.onClick.AddListener(OnStartButton);
      }

      protected override void OnDisable()
      {
         _startButton.onClick.RemoveListener(OnStartButton);
      }

      protected override void Show()
      {
         base.Show();
         
         _levelModel.SetPause(true);
      }

      private async void OnStartButton()
      {
         Hide();

         await Task.Delay(TimeSpan.FromSeconds(DelayBeforeUnpauseSeconds));

         _levelModel.SetPause(false);
      }
   }
}
