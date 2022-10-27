namespace Battleship.View;


public static class Input
{
    public static string? GetUserName()
    {
        return Console.ReadLine();
    }

    public static int GetValidShipNumber()
    {
        while (true)
        {
            string userInput = Console.ReadLine() ?? String.Empty;
            try
            {
                int value = int.Parse(userInput);
                if (value >= 1 && value <= 5)
                {
                    return value;
                }
                else
                {
                    Display.PrintMessage("Number out fo range, try again");
                }
            }
            catch(FormatException)
            {
                Display.PrintMessage("Please enter valid numbers");
            }
        }
    }

    public static (int, int) GetValidCoordinates()
    {
        while (true)
        {
            string coordinates = Console.ReadLine() ?? String.Empty;
            if (coordinates.ToUpper() == "Q" || coordinates.ToUpper() == "QUIT" || coordinates.ToUpper() == "EXIT")
            {
                Environment.Exit(0);
            }
            else if (coordinates.Length == 2 && char.IsLetter(coordinates[0]) && char.IsDigit(coordinates[1]))
            {
                int row = char.ToUpper(coordinates[0]) - 65;
                int col = char.ToUpper(coordinates[1]) - 49;

                if (row > 14 || col > 14 || row == -1 || col == -1)
                {
                    Display.PrintMessage("Out of bounds");
                    continue;
                }

                return (row, col);
            }
            else if (coordinates.Length == 3 && char.IsLetter(coordinates[0]) && char.IsDigit(coordinates[1]) && char.IsDigit(coordinates[2]))
            {
                int row = char.ToUpper(coordinates[0]) - 65;
                int col = (((coordinates[1] - '0') * 10) + (coordinates[2] - '0')) - 1;

                if (row > 14 || col > 14 || row == -1 || col == -1)
                {
                    Display.PrintMessage("Out of bounds");
                    continue;
                }

                return (row, col);
            }
            else
            {
                Display.PrintMessage("Not valid coordinates");
            }
        }
    }

    public static int[] GetShipsType(int shipNumber)
    {
        int[] shipsType = new int[shipNumber];
        for (int i = 0; i < shipNumber; i++)
        {
            int userChoice = GetValidShipNumber();
            shipsType[i] = userChoice;
        }

        return shipsType;
    }

    public static int ChooseOption(string direction)
    {
        int option;
        while (true)
        {
            string? userOption = Console.ReadLine();
            if (direction.Contains(userOption))
            {
                try
                {
                    option = int.Parse(userOption);
                    break;
                }
                catch (FormatException)
                {
                    Display.PrintMessage("Not a valid option! Try again..");
                }
                
            }
            else
            {
                Display.PrintMessage("Not a valid option! Try again.");
            }
        }
        return option;
    }
}