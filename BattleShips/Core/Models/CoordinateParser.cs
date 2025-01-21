using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class CoordinateParser : ICoordinateParser
    {
        private readonly IGrid _grid;

        public CoordinateParser(IGrid grid)
        {
            _grid = grid;
        }

        public bool TryParse(string input, out Coordinate coordinate)
        {
            coordinate = null;
            if (input.Length < 2 || input.Length > 3)
            {
                return false;
            }

            char colChar = input[0];
            if (!char.IsLetter(colChar))
            {
                return false;
            }

            if (!int.TryParse(input.Substring(1), out int row))
            {
                return false;
            }

            int col = char.ToUpper(colChar) - 'A';
            row--; // Adjust for 0-based indexing

            if (row < 0 || row >= _grid.Size || col < 0 || col >= _grid.Size)
            {
                return false;
            }

            coordinate = new Coordinate(row, col);
            return true;
        }
    }
}