using BattleShips.Core.Enums;

namespace BattleShips.Core.Interfaces
{
    public interface IShip
    {
        int Size { get; }
        string Name { get; }
        bool IsSunk { get; }
        ShotResult Shoot();
    }
}