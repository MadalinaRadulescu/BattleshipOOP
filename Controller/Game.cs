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
         Display.PrintMessage(board.ToString());
      }
      
   }
}