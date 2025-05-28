namespace _Game.Scripts.Core.SpaceSystem
{
    public class RoomTransitionArgs
    {
        public int DoorID { get; }
        public int CurrentRoomID { get; }

        public RoomTransitionArgs(int doorID, int currentRoomID)
        {
            DoorID = doorID;
            CurrentRoomID = currentRoomID;
        }
    }
}