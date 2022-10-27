using System;
using System.Collections.Generic;
using Battleship.View;

namespace Battleship.Model;

public static class BoardFactory
{
    public static void RandomPlacement(Board playerBoard, List<Ship> playerShips)
    {
        var random = new Random();
        
        foreach (var ship in playerShips)
        {
            while (true)
            {
                (int row, int col) coordinates = (random.Next(14), random.Next(14));
                if (playerBoard.ocean[coordinates.row, coordinates.col].SquareStatus == Status.ship)
                {
                    Display.PrintMessage(" ");
                }
                else
                {
                    string validDirection = ValidateShipDirection(playerBoard, ship, coordinates);
                    // Display.PrintMessage(validDirection);
                    while (true)
                    {
                        int randomOption = random.Next(4);
                        if (validDirection.Contains(randomOption.ToString()))
                        {
                            switch (randomOption)
                            {
                                case 1:
                                    for (int i = 0; i < ship.ShipSize; i++)
                                    {
                                        playerBoard.ocean[coordinates.row + i, coordinates.col].SquareStatus = Status.ship;
                                    }
                                    break;
                
                                case 2:
                                    for (int i = 0; i < ship.ShipSize; i++)
                                    {
                                        playerBoard.ocean[coordinates.row, coordinates.col + i].SquareStatus = Status.ship;
                                    }
                                    break; 
                
                                case 3:
                                    for (int i = 0; i < ship.ShipSize; i++)
                                    {
                                        playerBoard.ocean[coordinates.row - i, coordinates.col].SquareStatus = Status.ship;
                                    }
                                    break; 
                
                                case 4:
                                    for (int i = 0; i < ship.ShipSize; i++)
                                    {
                                        playerBoard.ocean[coordinates.row, coordinates.col - i].SquareStatus = Status.ship;
                                    }
                                    break;
                            }
                            break;
                        }
                        
                    }
                    break;
                }
            }
        }
        Display.PrintBoard(playerBoard);
    }

    public static void ManualPlacement(Board playerBoard, List<Ship> playerShips, Player player)
    {
        Display.PrintMessage($"                {player.name}, place your ships!");
        Display.PrintBoard(playerBoard);
        foreach (var ship in playerShips)
        {
            
            Display.PrintMessage($"Where would you like to place your ship of length {ship.ShipSize}: \n");
            while (true)
            {
                (int row, int col) userCoordinates = Input.GetValidCoordinates();
                if (playerBoard.ocean[userCoordinates.row, userCoordinates.col].SquareStatus == Status.ship)
                {
                    Display.PrintMessage("There is already a ship there. Choose again.");
                }
                else
                {
                    string validDirection = ValidateShipDirection(playerBoard, ship, userCoordinates);
                    Display.PrintMessage(validDirection);
                    int userOption = Input.ChooseOption(validDirection);
                    Console.Clear();
                    switch (userOption)
                    {
                        case 1:
                            for (int i = 0; i < ship.ShipSize; i++)
                            {
                                playerBoard.ocean[userCoordinates.row + i, userCoordinates.col].SquareStatus = Status.ship;
                                foreach (var square in ship.Ships)
                                {
                                    square.Coordinates = (userCoordinates.row + i, userCoordinates.col);
                                }
                            }
                            break;
                
                        case 2:
                            for (int i = 0; i < ship.ShipSize; i++)
                            {
                                playerBoard.ocean[userCoordinates.row, userCoordinates.col + i].SquareStatus = Status.ship;
                                foreach (var square in ship.Ships)
                                {
                                    square.Coordinates = (userCoordinates.row + i, userCoordinates.col);
                                }
                            }
                            break; 
                
                        case 3:
                            for (int i = 0; i < ship.ShipSize; i++)
                            {
                                playerBoard.ocean[userCoordinates.row - i, userCoordinates.col].SquareStatus = Status.ship;
                                foreach (var square in ship.Ships)
                                {
                                    square.Coordinates = (userCoordinates.row + i, userCoordinates.col);
                                }
                            }
                            break; 
                
                        case 4:
                            for (int i = 0; i < ship.ShipSize; i++)
                            {
                                playerBoard.ocean[userCoordinates.row, userCoordinates.col - i].SquareStatus = Status.ship;
                                foreach (var square in ship.Ships)
                                {
                                    square.Coordinates = (userCoordinates.row + i, userCoordinates.col);
                                }
                            }
                            break;
                    }
                    break;
                }
                
            }
            Display.PrintBoard(playerBoard);

        }

    }

    private static string ValidateShipDirection(Board playerBoard, Ship ship, (int row, int col) coordinates)
    {
        string shipDirection = "\nNow, please select the direction you want the ship to go\n";
        
        try
        {
            int validDirection = 0;
            for (int i = 0; i < ship.ShipSize; i++)
            {
                if (playerBoard.ocean[coordinates.row + i, coordinates.col].SquareStatus == Status.empty)
                {
                    validDirection++;
                }
            }

            if (validDirection == ship.ShipSize && coordinates.row + ship.ShipSize < 15)
            {
                shipDirection += "1-Down\n";
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine(" ");
        }
        
        try
        {
            int validDirection = 0;
            for (int i = 0; i < ship.ShipSize; i++)
            {
                if (playerBoard.ocean[coordinates.row , coordinates.col +i].SquareStatus == Status.empty)
                {
                    validDirection++;
                }
            }

            if (validDirection == ship.ShipSize && coordinates.col + ship.ShipSize < 15)
            {
                shipDirection += "2-Right\n";
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine(" ");
        }
        
        try
        {
            int validDirection = 0;
            for (int i = 0; i < ship.ShipSize; i++)
            {
                if (playerBoard.ocean[coordinates.row - i, coordinates.col].SquareStatus == Status.empty)
                {
                    validDirection++;
                }
            }

            if (validDirection == ship.ShipSize && coordinates.row - ship.ShipSize >= 0)
            {
                shipDirection += "3-Up\n";
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine(" ");
        }
        
        try
        {
            int validDirection = 0;
            for (int i = 0; i < ship.ShipSize; i++)
            {
                if (playerBoard.ocean[coordinates.row , coordinates.col - i].SquareStatus == Status.empty)
                {
                    validDirection++;
                }
            }

            if (validDirection == ship.ShipSize && coordinates.col - ship.ShipSize >=0)
            {
                shipDirection += "4-Left\n";
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine(" ");
        }

        return shipDirection;

    }
}