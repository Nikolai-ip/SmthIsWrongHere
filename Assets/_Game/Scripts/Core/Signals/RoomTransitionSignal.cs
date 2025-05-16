using _Game.Scripts.Core.SpaceSystem;

namespace _Game.Scripts.Core.Signals
{
    public class RoomTransitionSignal:ISignal
    {
        public RoomTransitionArgs Args { get;  }

        public RoomTransitionSignal(RoomTransitionArgs args)
        {
            Args = args;
        }
    }
}