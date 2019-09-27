using System;
using System.Collections.Generic;

namespace Zork
{
    class Program
    {
        private static (int row, int column) Location;
        private static readonly string[,] Rooms = {
            { "Rocky Trail","South of House", "Canyon View" },
            {"Forest","West of House","Behind House" },
            {"Dense Woods", "North of House", "Clearing" }
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Location.row = 1;
            Location.column = 1;

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Rooms[Location.row, Location.column]);
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString = "";
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:

                    case Commands.SOUTH:

                    case Commands.EAST:
        
                    case Commands.WEST:

                        if (Move(command) == false)

                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        outputString = "Unknown command.";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool Move(Commands command)
        {
            bool isValid = true;

            if (command == Commands.NORTH || command == Commands.SOUTH || command == Commands.EAST || command == Commands.WEST)
            {
                switch (command)
                {
                    case Commands.NORTH when Location.row > 0:
                        Location.row--;
                        break;

                    case Commands.SOUTH when Location.row + 1 < Rooms.GetLength(0):
                        Location.row++;
                        break;

                    case Commands.EAST when Location.column + 1 < Rooms.GetLength(1):
                        Location.column++;
                        break;

                    case Commands.WEST when Location.column > 0:
                        Location.column--;
                        break;

                    default:
                        isValid = false;
                        break;
                }
            }

            return isValid;
        }

        };

}
