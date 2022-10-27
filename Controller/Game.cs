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
         bool winCondition1 = player1.IsAlive(player2.playerBoard);
         bool winCondition2 = player2.IsAlive(player1.playerBoard);
         var shipsSize = SetUpGame();
         SetUpPlayer(shipsSize, player1);
         SetUpPlayer(shipsSize, player2);
         Display.PrintParallelBoard(player1.playerGuessBoard, player2.playerGuessBoard, player1.name, player2.name);
         while (winCondition1 || winCondition2)
         {
            
            ShootPlayer(player1, player2);
            Display.PrintParallelBoard(player1.playerGuessBoard, player2.playerGuessBoard, player1.name, player2.name);
            if (player1.IsAlive(player2.playerBoard))
            {
               Display.PrintMessage($"{player1.name} WON!");
               break;
            }

            ShootPlayer(player2, player1);
            Display.PrintParallelBoard(player1.playerGuessBoard, player2.playerGuessBoard, player1.name, player2.name);
            if (player2.IsAlive(player1.playerBoard))
            {
               Display.PrintMessage($"{player2.name} WON!");
               break;
            }
            
            
            
         }
      }

      private static int[] SetUpGame()
      {
         Display.PrintMessage("Welcome to BATTLESHIP!\nPLease set up your game.\n");
         Display.PrintMessage("Choose how many ships you want to play with (1-5): \n");
         int numShips = Input.GetValidShipNumber();
         Display.PrintMessage(
            $"Choose the type of ships you want to play ({numShips}):\n 1 - Carrier \n 2 - Cruiser\n 3 - Battleship\n 4 - Submarine\n 5 - Destroyer ");
         int[] shipsSize = Input.GetShipsType(numShips);
         return shipsSize;
      }

      private void ShootPlayer(Player player, Player enemyPlayer)
      {
         Display.PrintMessage($"{player.name}'s turn to shoot:");
         player.Shoot(enemyPlayer.playerBoard, enemyPlayer.playerGuessBoard);
         Console.Clear();
         
      }

      private void SetUpPlayer(int[] shipsSize, Player player)
      {
         Display.PrintMessage("Please enter your name:\n");
         player.name = Input.GetUserName();
         player.playerShips = player.GetPlayerShips(shipsSize);
         BoardFactory.ManualPlacement(player.playerBoard, player.playerShips, player1);
      }
   }
}