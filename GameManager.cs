namespace ObjectFountain;

public class GameManager
{
  public Room[,] Grid { get; private set; }
  
  private Random _random;

  public GameManager()
  {
    _random = new Random();
  }
  
  public void GenerateGrid(int size)
  {
    Grid = new Room[size, size];
    
    for (int i = 0; i < size; i++)
    {
      for (int j = 0; j < size; j++)
      {
        Grid[i, j] = new Room(i, j);
      }
    }

    AssignRooms(size);
  }

  private void AssignRooms(int size)
  {
    Grid[0, 0] = new EntranceRoom(0, 0);

    if (size == 4)
    {
      Grid[0, 2] = new FountainRoom(0, 2);
      Grid[2, 1] = new PitRoom(2, 1);
    }
    else if (size == 6)
    {
      Grid[0, 4] = new FountainRoom(0, 4);
      Grid[2, 1] = new PitRoom(2, 1);
      Grid[4, 3] = new PitRoom(4, 3);
    }
    else if (size == 8)
    {
      Grid[0, 6] = new FountainRoom(0, 6);
      Grid[2, 1] = new PitRoom(2, 1);
      Grid[4, 3] = new PitRoom(4, 3);
      Grid[6, 6] = new PitRoom(6, 6);
    }
  }
}