using BattleShips.UserInterface.Interfaces;

namespace BattleShips.UserInterface.Models
{
    public class ConsoleOutput : IConsoleOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}