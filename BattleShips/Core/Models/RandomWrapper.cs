using BattleShips.Core.Interfaces;

namespace BattleShips.Core.Models
{
    public class RandomWrapper : IRandom
    {
        private readonly Random _random;

        public RandomWrapper()
        {
            _random = new Random();
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}