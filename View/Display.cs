
using Battleship.Model;

namespace Battleship.View
{
    public static class Display
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void PrintBoard(Board playerBoard)
        {
            Console.WriteLine(playerBoard.ToString());
        }
    } 
    
    
}
