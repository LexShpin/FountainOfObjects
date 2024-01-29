

using ObjectFountain;

GameManager gameManager = new GameManager();
int gridSize = 0;

while (true)
{
  Console.Write("Would you like to play a small, medium or large game? ");
  string gameSize = Console.ReadLine();

  if (gameSize == "small")
  {
    gridSize = 4;
    gameManager.GenerateGrid(gridSize);
    break;
  }
  else if (gameSize == "medium")
  {
    gridSize = 6;
    gameManager.GenerateGrid(gridSize);
    break;
  }
  else if (gameSize == "large")
  {
    gridSize = 8;
    gameManager.GenerateGrid(gridSize);
    break;
  }
  else
  {
    Console.WriteLine("That option is not available!");
  }

}

int currentRow = 0;
int currentColumn = 0;
Room currentRoom = null;

while (true)
{
  ShowRoundInfo();
  
  if (currentRoom is EntranceRoom && Fountain.IsActivated)
  {
    break;
  }
  
  Console.Write("What do you want to do? ");
  string playersMove = Console.ReadLine();

  if (playersMove != null)
  {
    if (playersMove == "quit")
      break;
    
    HandlePlayerActions(playersMove);
  }
}

void ShowRoundInfo()
{
  currentRoom = gameManager.Grid[currentRow, currentColumn];
  Console.WriteLine($"You are in the room at (Row={currentRow} Column={currentColumn})");
  
  if (currentRoom.RoomClue != null)
    currentRoom.ShowRoomMessage();
}

void HandlePlayerActions(string playersMove)
{
  if (playersMove == "move north")
  {
    if (currentRow - 1 < 0)
    {
      Console.WriteLine("You can't move outside the board!");
    }
    else
    {
      currentRow--;
    }
  }

  if (playersMove == "move south")
  {
    if (currentRow + 1 > gridSize - 1)
    {
      Console.WriteLine("You can't move outside the board!");
    }
    else
    {
      currentRow++;
    }
  }
  
  if (playersMove == "move west")
  {
    if (currentColumn - 1 < 0)
    {
      Console.WriteLine("You can't move outside the board!");
    }
    else
    {
      currentColumn--;
    }
  }
  
  if (playersMove == "move east")
  {
    if (currentColumn + 1 > gridSize - 1)
    {
      Console.WriteLine("You can't move outside the board!");
    }
    else
    {
      currentColumn++;
    }
  }

  if (currentRoom is FountainRoom)
  {
    if (!Fountain.IsActivated && playersMove == "enable fountain")
      Fountain.IsActivated = true;

    if (Fountain.IsActivated && playersMove == "disable fountain")
      Fountain.IsActivated = false;
  }
}