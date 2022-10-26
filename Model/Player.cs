namespace Battleship.Model;

public class Player
{
    private List<Ship> playerShips;
    private bool IsAlive;
    
    public Player()
    {
        Board playerBoard = new Board();
        playerShips = new List<Ship>();
    }
}