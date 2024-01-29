namespace ObjectFountain;

public class FountainRoom : Room
{
  public FountainRoom(int row, int column) : base(row, column)
  {
    RoomClue = "You hear water dripping in this room. The Fountain of Objects is here!";
  }

  public override void ShowRoomMessage()
  {
    if (Fountain.IsActivated)
      RoomClue = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
    else
      RoomClue = "You hear water dripping in this room. The Fountain of Objects is here!";

    Console.WriteLine(RoomClue);
  }
}