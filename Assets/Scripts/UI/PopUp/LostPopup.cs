using GameStates;
using GameStates.States;

namespace UI.PopUp
{
   public class LostPopup : BasePopup
   {
      protected override void OnChangeState(BaseGameState gameState)
      {
         if (gameState is EnterGameState)
            Hide();
         
         if (gameState is LostGameState)
            Show();
      }
   }
}
