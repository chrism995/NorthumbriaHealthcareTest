using BattleShips.Core.Models;

namespace BattleShips.Core.Interfaces
{
    public interface IGame
    {
        void Start();
        void PlaceShips();
        bool TryParseCoordinate(string input, out Coordinate coordinate);
    }
}