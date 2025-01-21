namespace BattleShips.UserInterface.Interfaces
{
    //Abstracting the Console.WriteLine() method to allow for easier testing & Extensibility/Flexibility
    public interface IConsoleOutput
    {
        void WriteLine(string message);
    }
}