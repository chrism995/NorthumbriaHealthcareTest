using BattleShips.Core.Enums;
using BattleShips.Core.Models;

namespace BattleShips.Core.Interfaces
{
    public interface IGrid
    {
        int Size { get; }
        bool PlaceShip(IShip ship, Coordinate start, Orientation orientation);
        ShotResult Shoot(Coordinate coordinate);
        bool AllShipsSunk();
    }
}