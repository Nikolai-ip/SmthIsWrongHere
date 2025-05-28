namespace _Game.Scripts.Core.SpaceSystem.RoomTransitonHandlers
{
    public interface IRoomTransitionEventHandler
    {
        void OnExit();
        void OnEnter();
    }
}