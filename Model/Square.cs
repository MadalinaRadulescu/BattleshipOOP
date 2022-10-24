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

    public char GetCharacter(Status squareStatus)
    {
        char uniCharacter = ' ';
        switch (squareStatus)
        {
            case Status.hit:
                uniCharacter = 'X';
                break;
            case Status.ship:
                uniCharacter =  '#';
                break;
            case Status.miss:
                uniCharacter =  'o';
                break;
            case Status.empty:
                uniCharacter =  '~';
                break;
            case Status.sunk:
                uniCharacter =  '$';
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