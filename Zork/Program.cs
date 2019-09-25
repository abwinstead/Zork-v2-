using System;
using System.Collections.Generic;

namespace Zork
{
    class Program
    {
        private static string[] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
        private static int i = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write(Rooms[i]);
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
                        if (Move(command) == false)
                        {
                            outputString = "The way is shut!";
                        }
                        break;
                    case Commands.SOUTH:
                        if (Move(command) == false)
                        {
                            outputString = "The way is shut!";
                        }
                        break;
                    case Commands.EAST:
                        if (i + 1 < Rooms.Length)
                        {
                            outputString = $"You moved {command}.";
                            i++;
                        }
                        else
                        {
                            outputString = $"The way is shut!";
                        }
                        break;
                    case Commands.WEST:
                        if (i - 1 >= 0)
                        {
                            outputString = $"You moved {command}.";
                            i--;
                        }
                        else
                        {
                            outputString = $"The way is shut!";
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

            if (command == Commands.NORTH || command == Commands.SOUTH)
            {
                isValid = false;
            }

            return isValid;

        }

    }
}