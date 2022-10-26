namespace Battleship.Model;

public class Player
{
    public List<Ship> playerShips;
    public Board playerBoard;
    public bool IsAlive;
    public string name;
    
    public Player()
    {
        playerBoard = new Board();
        playerShips = new List<Ship>();
        
    }

    public List<Ship> GetPlayerShips(int[] shipsSize)
    {
        foreach (var item in shipsSize)
        {
            Ship ship = new Ship(item);
            playerShips.Add(ship);
        }

        return playerShips;
    }
}