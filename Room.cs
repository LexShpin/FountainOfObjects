namespace ObjectFountain;

public class Room
{
  public int Row { get; }
  public int Column { get; }
  public string RoomClue { get; set; } = null;

  public Room(int row, int column)
  {
    Row = row;
    Column = column;
  }

  public virtual void ShowRoomMessage()
  {
  
  }
}