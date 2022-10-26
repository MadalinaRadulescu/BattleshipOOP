namespace Battleship.Model;

public class Ship
{
    public List<Square> Ships;
    private Type ShipType { get; set; }
    public int ShipSize; 
    
    public Ship(int shipSize)
    {
        ShipSize = shipSize;
        Ships = new List<Square>();
        CreateShip(ShipSize);

    }

    public List<Square> CreateShip(int shipSize)
    {
        
        for (int i = 0; i < shipSize; i++)
        {
            Square shipPart = new Square(Status.ship);
            Ships.Add(shipPart);
        }
        
        return Ships;
    }
}

public enum Type
{
    Carrier=1,
    Cruiser=2,
    Battleship=3,
    Submarine=4,
    Destroyer=5
}