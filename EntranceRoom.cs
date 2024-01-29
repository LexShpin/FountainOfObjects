namespace ObjectFountain;

public class EntranceRoom : Room
{
  
  public EntranceRoom(int row, int column) : base(row, column)
  {
    RoomClue = "You see light coming from the cavern entrance";
  }

  public override void ShowRoomMessage()
  {
    if (Fountain.IsActivated)
      RoomClue = @"The Fountain of Objects has been reactivated, and you have escaped with your life!
You win!";
    else
      RoomClue = "You see light coming from the cavern entrance";

    Console.WriteLine(RoomClue);
  }
}