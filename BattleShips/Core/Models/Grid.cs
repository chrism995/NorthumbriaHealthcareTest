using BattleShips.Core.Enums;
using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class Grid : IGrid
    {
        public int Size { get; }
        private readonly IShip?[,] _grid;
        private readonly List<IShip> _ships;

        public Grid(int size)
        {
            Size = size;
            _grid = new IShip?[size, size];
            _ships = new List<IShip>();
        }

        public bool PlaceShip(IShip ship, Coordinate start, Orientation orientation)
        {
            if (!IsValidPlacement(ship, start, orientation))
            {
                return false;
            }

            for (int i = 0; i < ship.Size; i++)
            {
                int row = start.Row;
                int col = start.Column;

                if (orientation == Orientation.Horizontal)
                {
                    col += i;
                }
                else
                {
                    row += i;
                }
                _grid[row, col] = ship;
            }

            _ships.Add(ship);
            return true;
        }

        public ShotResult Shoot(Coordinate coordinate)
        {
            if (coordinate.Row < 0 || coordinate.Row >= Size || coordinate.Column < 0 || coordinate.Column >= Size)
            {
                throw new ArgumentOutOfRangeException("Coordinate is out of bounds");
            }

            IShip? ship = _grid[coordinate.Row, coordinate.Column];
            if (ship == null)
            {
                return ShotResult.Miss;
            }

            _grid[coordinate.Row, coordinate.Column] = null; 
            return ship.Shoot();
        }

        public bool AllShipsSunk()
        {
            return _ships.All(s => s.IsSunk);
        }

        private bool IsValidPlacement(IShip ship, Coordinate start, Orientation orientation)
        {
            if (start.Row < 0 || start.Column < 0) return false;
            if (orientation == Orientation.Horizontal && start.Column + ship.Size > Size) return false;
            if (orientation == Orientation.Vertical && start.Row + ship.Size > Size) return false;

            for (int i = 0; i < ship.Size; i++)
            {
                int row = start.Row;
                int col = start.Column;

                if (orientation == Orientation.Horizontal)
                {
                    col += i;
                }
                else
                {
                    row += i;
                }

                if (row >= Size || col >= Size || _grid[row, col] != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}