namespace BattleShips.UserInterface.Interfaces
{
    //Abstracting the Console.ReadLine() method to allow for easier testing & Extensibility/Flexibility
    public interface IConsoleInput
    {
        string ReadLine();
    }
}