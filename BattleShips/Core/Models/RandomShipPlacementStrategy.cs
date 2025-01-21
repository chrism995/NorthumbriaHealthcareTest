using BattleShips.Core.Enums;
using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class RandomShipPlacementStrategy : IShipPlacementStrategy
    {
        private readonly IRandom _random;

        public RandomShipPlacementStrategy(IRandom random)
        {
            _random = random;
        }

        public void PlaceShips(IGrid grid, IShipFactory shipFactory)
        {
            PlaceShip(grid, shipFactory.CreateBattleship());
            PlaceShip(grid, shipFactory.CreateDestroyer());
            PlaceShip(grid, shipFactory.CreateDestroyer());
        }
        
        private void PlaceShip(IGrid grid, IShip ship)
        {
            bool placed = false;
            while (!placed)
            {
                int row = _random.Next(0, grid.Size);
                int col = _random.Next(0, grid.Size);
                Orientation orientation = _random.Next(0, 2) == 0 ? Orientation.Horizontal : Orientation.Vertical;

                placed = grid.PlaceShip(ship, new Coordinate(row, col), orientation);
            }
        }
    }
}