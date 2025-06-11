using UnityEngine.Events;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class SwitchLampMiniGameContext:MiniGameContext
    {
        public override MiniGameType Type => MiniGameType.SwitchLamp;
        public UnityEvent OnMiniGameReset;
        public override void ResetGame()
        {
            base.ResetGame();
            OnMiniGameReset?.Invoke();
        }
    }
}