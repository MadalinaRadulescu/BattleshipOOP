namespace Battleship.Model;

public class Ship
{
    public List<Square> ships;
    private Type ShipType { get; set; }
    

    public Ship(List<Square> ships, Type shipType)
    {
        
    }

    // public List<Square> CreateShip(int shipSize)
    // {
    //     for (int i = 0; i < shipSize; i++)
    //     {
    //     }
    // }
}

public enum Type
{
    Carrier=1,
    Cruiser=2,
    Battleship=3,
    Submarine=4,
    Destroyer=5
}