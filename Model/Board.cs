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

}