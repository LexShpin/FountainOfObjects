namespace ObjectFountain;

public class PitRoom : Room
{
  public PitRoom(int row, int column) : base(row, column)
  {
  }

  public new static void ShowRoomMessage()
  {
    Console.WriteLine("Pitroom nearby");
  }
  
}