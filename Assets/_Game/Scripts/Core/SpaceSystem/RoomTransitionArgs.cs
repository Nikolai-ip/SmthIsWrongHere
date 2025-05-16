namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomTransitionArgs
    {
        public int DoorID { get; }

        public RoomTransitionArgs(int doorID)
        {
            DoorID = doorID;
        }
    }
}