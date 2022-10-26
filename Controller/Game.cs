using Battleship.Model;
using Battleship.View;

namespace Battleship.Controller
{
   public class Game
   {
      // Board board = new Board();
      
      private Player player1 = new Player();
      private Player player2 = new Player();

      public Game()
      {
      }

      public void Play()
      {
         Display.PrintMessage("Welcome to BATTLESHIP!\nPLease set up your game.\nPlayer 1 please enter your name:\n");
         player1.name = Input.GetUserName();
         Display.PrintMessage($"{player1.name} choose how many ships you want to play with (1-5): \n");
         int numShips = Input.GetValidShipNumber();
         Display.PrintMessage($"{player1.name} choose the type of ships you want to play ({numShips}):\n 1 - Carrier \n 2 - Cruiser\n 3 - Battleship\n 4 - Submarine\n 5 - Destroyer ");
         int[] shipsSize = Input.GetShipsType(numShips);
         player1.playerShips = player1.GetPlayerShips(shipsSize);
         BoardFactory.ManualPlacement(player1.playerBoard, player1.playerShips, player1);
         
         
         
      }
      
   }
}