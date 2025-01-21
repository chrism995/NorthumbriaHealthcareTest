using BattleShips.Core.Enums;
using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class Grid : IGrid
    {
        public int Size { get; }
        private readonly IShip?[,] _grid;
        private readonly List<IShip> _ships;

        /// <summary>
        /// Create a new grid
        /// </summary>
        /// <param name="size">The size of the grid</param>
        public Grid(int size)
        {
            Size = size;
            _grid = new IShip?[size, size];
            _ships = new List<IShip>();
        }

        /// <summary>
        /// Place a ship on the grid
        /// </summary>
        /// <param name="ship">The ship to place</param>
        /// <param name="start">The starting coordinate</param>
        /// <param name="orientation">The orientation of the ship</param>
        /// <returns>True if the ship was placed, otherwise false</returns>
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

        /// <summary>
        /// Shoot at the grid
        /// </summary>
        /// <param name="coordinate">The coordinate to shoot at</param>
        /// <returns>The result of the shot</returns>
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

        /// <summary>///
        /// Check if the ship can be placed on the grid
        /// </summary>
        /// <param name="ship">The ship to place</param>
        /// <param name="start">The starting coordinate</param>
        /// <param name="orientation">The orientation of the ship</param>
        /// <returns>True if the ship can be placed, otherwise false</returns>
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

                // Check if the cell is out of bounds or already occupied
                if (row >= Size || col >= Size || _grid[row, col] != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}