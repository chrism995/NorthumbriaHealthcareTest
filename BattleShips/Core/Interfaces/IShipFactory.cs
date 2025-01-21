namespace BattleShips.Core.Interfaces
{
    public interface IShipFactory
    {
        IShip CreateBattleship();
        IShip CreateDestroyer();
    }
}