namespace BattleShips.Core.Interfaces
{
    public interface IShipPlacementStrategy
    {
        void PlaceShips(IGrid grid, IShipFactory shipFactory);
    }
}