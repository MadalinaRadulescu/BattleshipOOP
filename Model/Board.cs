using System.Text;

namespace Battleship.Model;

public class Board
{
    public Square[,] ocean { get; set; }
    private int size = 15;
    

    public Board()
    {
        ocean = new Square[size, size];
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                ocean[row, col] = new Square((row, col), Status.empty);
            }
        }
    }

    

    public override string ToString()
    {
        
        StringBuilder sb = new StringBuilder();
        // sb.Append("   1  2  3  4  5  6  7  8  9 10 11 12 13 14 15\n");
        for (int row = 0; row < 15; row++)
        {
            sb.Append((char)(row + 65));
            sb.Append("  ");
            for (int col = 0; col < 15; col++)
            {
                char character = ocean[row, col].GetCharacter(ocean[row, col].SquareStatus);
                sb.Append($"{character}  ");
            }

            sb.Append("\n");
        }

        return sb.ToString();
    }
    public string ToStringParallel(Board player1Board, Board player2Board)
    {
        StringBuilder sb = new StringBuilder();
        // sb.Append("   1  2  3  4  5  6  7  8  9 10 11 12 13 14 15      |      \n");
        for (int row = 0; row < 15; row++)
        {
            sb.Append((char)(row + 65));
            sb.Append("  ");
            for (int col = 0; col < 15; col++)
            {
                Status squareStatus = player1Board.ocean[row, col].SquareStatus;
                char character = player1Board.ocean[row, col].GetCharacter(squareStatus);
                sb.Append($"{character}  ");
            }

            sb.Append("      |      ");
            sb.Append((char)(row + 65));
            sb.Append("  ");
            for (int col = 0; col < 15; col++)
            {
                Status squareStatus = player2Board.ocean[row, col].SquareStatus;
                char character = player2Board.ocean[row, col].GetCharacter(squareStatus);
                sb.Append($"{character}  ");
            }

            sb.Append("\n");

        }
        

        return sb.ToString();
    }
}