namespace Battleship.Model;

public class Square
{
    public (int x, int y) Coordinates { get; set; }
    public Status SquareStatus { get; set; }

    public Square((int x, int y) coordinates, Status squareStatus)
    {
        this.SquareStatus = squareStatus;
        this.Coordinates = coordinates;
    }
    
    public Square(Status squareStatus)
    {
        SquareStatus = squareStatus;
    }

    public string GetCharacter(Status squareStatus)
    {
        string uniCharacter = " ";
        switch (squareStatus)
        {
            case Status.hit:
                uniCharacter = "🔥";
                break;
            case Status.ship:
                uniCharacter =  "🚢";
                break;
            case Status.miss:
                uniCharacter =  "🌊";
                break;
            case Status.empty:
                uniCharacter =  "~ ";
                break;
            case Status.sunk:
                uniCharacter =  "⚓️";
                break;
        }

        return uniCharacter;
    }


}

public enum Status
{
    sunk,
    empty, 
    ship,
    miss, 
    hit,
}