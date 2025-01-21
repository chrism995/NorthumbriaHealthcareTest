using BattleShips.Core.Models;

namespace BattleShips.Core.Interfaces
{
    public interface ICoordinateParser
    {
        public bool TryParse(string input, out Coordinate coordinate);
    }
}