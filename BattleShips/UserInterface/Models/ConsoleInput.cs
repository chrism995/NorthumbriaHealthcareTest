using BattleShips.UserInterface.Interfaces;

namespace BattleShips.UserInterface.Models
{
    public class ConsoleInput : IConsoleInput
    {
        public string ReadLine()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return Console.ReadLine();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}