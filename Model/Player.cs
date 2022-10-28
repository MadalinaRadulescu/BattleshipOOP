
using Battleship.View;
using System.Data;
using System;
using System.Linq;
using System.Collections.Generic;



namespace Battleship.Model;

public class Player
{
    public List<Ship> playerShips;
    public Board playerBoard;
    public Board playerGuessBoard;
    // public bool IsAlive;
    public string name;
    
    public Player()
    {
        playerGuessBoard = new Board();
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
    
    public void Shoot(Board playerBoard, Board guessBoard, List<Ship> playerShips)
    {
        while (true)
        {
            Display.PrintMessage("Enter coordinates to shoot at");
            (int x, int y) coordinates = Input.GetValidCoordinates();
            if (playerBoard.ocean[coordinates.x, coordinates.y].SquareStatus == Status.ship)
            {
                playerBoard.ocean[coordinates.x, coordinates.y].SquareStatus = Status.hit;
                guessBoard.ocean[coordinates.x, coordinates.y].SquareStatus = Status.hit;
                foreach (var ship in playerShips)
                {
                    foreach (var square in ship.Ships)
                    {
                        if (square.Coordinates == (coordinates.x, coordinates.y) )
                        {
                            square.SquareStatus = Status.hit;
                            
                        }
                        
                    }
                    
                }
                break;
            }
            else if (playerBoard.ocean[coordinates.x, coordinates.y].SquareStatus == Status.empty)
            {
                playerBoard.ocean[coordinates.x, coordinates.y].SquareStatus = Status.miss;
                guessBoard.ocean[coordinates.x, coordinates.y].SquareStatus = Status.miss;
                break;
            }
            else
            {
                Display.PrintMessage("You already took a shot there, try again!");
            }
        }
    }

    public bool IsAlive(Board playerBoard)
    {
        bool isAlive = true;
        for (int row = 0; row < 15; row++)
        {
            for (int col = 0; col < 15; col++)
            {
                if (playerBoard.ocean[row, col].SquareStatus == Status.ship)
                {
                    isAlive = false;
                    break;
                }
            }

        }

        return isAlive;
    }
}