
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
            string firstRow = "   1   2   3   4   5   6   7   8   9  10  11   12  13  14  15";
            Console.WriteLine($"{firstRow}");
            Console.WriteLine(playerBoard.ToString());
        }

        public static void PrintParallelBoard(Board player1Board, Board player2Board, string name1, string name2)
        {
            string firstRow = "   1   2   3   4   5   6   7   8   9  10  11   12  13  14  15";
            Console.WriteLine($"                  {name1}'s board                                                          {name2}' board");
            Console.WriteLine($"{firstRow}        |      {firstRow}");
            Console.WriteLine(player1Board.ToStringParallel(player1Board, player2Board));
        }
    } 
    
    
}
