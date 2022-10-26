using System.Text;

namespace Battleship.Model;

public class Board
{
    private Square[,] ocean { get; set; }
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

    public bool isPlacementOK() => throw new NotImplementedException();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("   1  2  3  4  5  6  7  8  9 10 11 12 13 14 15\n");
        for (int row = 0; row < 15; row++)
        {
            sb.Append((char)(row + 65));
            sb.Append("  ");
            for (int col = 0; col < 15; col++)
            {
                sb.Append("~  ");
            }

            sb.Append("\n");
        }

        return sb.ToString();
    }
}