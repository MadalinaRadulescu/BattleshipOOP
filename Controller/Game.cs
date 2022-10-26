using Battleship.Model;
using Battleship.View;

namespace Battleship.Controller
{
   public class Game
   {
      Board board = new Board();

      public Game()
      {
      }

      public void Play()
      {
         Display.PrintMessage("Welcome to BATTLESHIP!\nPLease set up your game.\nPlayer 1 please enter your name:\n");
         string player1Name = Input.GetUserName();
         Display.PrintMessage($"{player1Name} choose how many ships you want to play with (1-5): \n");
         int numShips = Input.GetValidShipNumber();
         Display.PrintMessage($"{player1Name} choose the type of ships you want to play ({numShips}):\n 1 - Carrier \n 2 - Cruiser\n 3 - Battleship\n 4 - Submarine\n 5 - Destroyer ");
         int[] shipSize = Input.GetShipsType(numShips);
         Display.PrintMessage($"{player1Name}, place your ships!");
         Display.PrintMessage(board.ToString());
         Display.PrintMessage("Please enter valid coordinates: \n");
      }
      
   }
}