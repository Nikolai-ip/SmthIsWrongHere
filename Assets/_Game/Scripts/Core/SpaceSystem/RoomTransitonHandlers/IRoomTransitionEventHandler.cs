namespace _Game.Scripts.Core.SpaceSystem.RoomTransitonHandlers
{
    public interface IRoomTransitionEventHandler
    {
        void OnEnter();
        void OnExit();
    }
}