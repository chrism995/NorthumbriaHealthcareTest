using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class ShipFactory : IShipFactory
    {
        public IShip CreateBattleship()
        {
            return new Ship("Battleship", 5);
        }

        public IShip CreateDestroyer()
        {
            return new Ship("Destroyer", 4);
        }
    }
}