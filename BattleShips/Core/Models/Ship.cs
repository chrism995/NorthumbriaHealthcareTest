using BattleShips.Core.Enums;
using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class Ship : IShip
    {
        public int Size { get; }
        public string Name { get; }
        public bool IsSunk { get; private set; }
        private int _hits;

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            IsSunk = false;
            _hits = 0;
        }

        public ShotResult Shoot()
        {
            _hits++;
            if (_hits == Size)
            {
                IsSunk = true;
                return ShotResult.Sink;
            }
            return ShotResult.Hit;
        }
    }
}