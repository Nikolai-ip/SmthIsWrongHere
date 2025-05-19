namespace _Game.Scripts.Features.MiniGames
{
    public class NoneMiniGameContext: MiniGameContext
    {
        public override MiniGameType Type => MiniGameType.None;

        public override void ResetGame()
        {
            
        }
    }
}