using BattleShips.UserInterface.Interfaces;

namespace BattleShips.UserInterface.Models
{
    public class ConsoleInput : IConsoleInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}