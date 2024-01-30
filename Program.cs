

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
DateTime gameStart = DateTime.Now;

while (true)
{
  if (currentRoom is PitRoom)
  {
    Console.WriteLine("You fell into a pit! Game over.");
    DateTime gameFinish = DateTime.Now;
    TimeSpan gameTime = gameFinish - gameStart;
    Console.WriteLine($"You've spent {gameTime.Minutes}m {gameTime.Seconds}s in the cavern");
    break;
  }
  
  ShowRoundInfo();
  
  if (currentRoom is EntranceRoom && Fountain.IsActivated)
  {
    DateTime gameFinish = DateTime.Now;
    TimeSpan gameTime = gameFinish - gameStart;
    Console.WriteLine($"You've spent {gameTime.Minutes}m {gameTime.Seconds}s in the cavern");
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
  
  CheckForPitRoomNearby();
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
      --currentRow;
      currentRoom = gameManager.Grid[currentRow, currentColumn];
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
      ++currentRow;
      currentRoom = gameManager.Grid[currentRow, currentColumn];
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
      --currentColumn;
      currentRoom = gameManager.Grid[currentRow, currentColumn];
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
      ++currentColumn;
      currentRoom = gameManager.Grid[currentRow, currentColumn];
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

void CheckForPitRoomNearby()
{
  if (gridSize == 4)
    HandleSmallGridPit();
  
  if (gridSize == 6)
    HandleMediumGridPits();
  
  if (gridSize == 8)
    HandleLargeGridPits();
}

void HandleSmallGridPit()
{
  if (currentRow == 1 && currentColumn == 0)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 1 && currentColumn == 1)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 1 && currentColumn == 2)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 2 && currentColumn == 0)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 2 && currentColumn == 2)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 3 && currentColumn == 0)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 3 && currentColumn == 1)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 3 && currentColumn == 2)
    PitRoom.ShowRoomMessage();

  if (currentRow == 2 && currentColumn == 1)
    currentRoom = gameManager.Grid[currentRow, currentColumn];
}

void HandleMediumGridPits()
{
  HandleSmallGridPit();
  
  if (currentRow == 3 && currentColumn == 2)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 3 && currentColumn == 3)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 3 && currentColumn == 4)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 4 && currentColumn == 2)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 4 && currentColumn == 4)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 5 && currentColumn == 2)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 5 && currentColumn == 3)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 5 && currentColumn == 4)
    PitRoom.ShowRoomMessage();
}

void HandleLargeGridPits()
{
  HandleSmallGridPit();
  HandleMediumGridPits();
  
  if (currentRow == 5 && currentColumn == 5)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 5 && currentColumn == 6)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 5 && currentColumn == 7)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 6 && currentColumn == 5)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 6 && currentColumn == 7)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 7 && currentColumn == 5)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 7 && currentColumn == 6)
    PitRoom.ShowRoomMessage();
  
  if (currentRow == 7 && currentColumn == 7)
    PitRoom.ShowRoomMessage();
}