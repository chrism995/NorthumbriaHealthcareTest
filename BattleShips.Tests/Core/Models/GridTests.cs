using BattleShips.Core.Enums;
using BattleShips.Core.Interfaces;
using BattleShips.Core.Models;
using Moq;
using Xunit;

namespace BattleShips.Tests.Core.Models
{
    public class GridTests
    {
        [Fact]
        public void PlaceShip_ValidHorizontalPlacement_ReturnsTrue()
        {  
            PlaceShip_Horizontally_Outside_Bounds_ReturnsFalse          
            var grid = new Grid(10);
            var ship = new Ship("Destroyer", 3);
            var startCoordinate = new Coordinate(0, 0);

            bool result = grid.PlaceShip(ship, startCoordinate, Orientation.Horizontal);

            Assert.True(result);
        }

        // Attempt to place ship outside grid bounds horizontally
        [Fact]
        public void PlaceShip_Horizontally_Outside_Bounds_ReturnsFalse()
        { 
            var grid = new Grid(10);
            var mockShip = new Mock<IShip>();
            mockShip.Setup(s => s.Size).Returns(3);
            var start = new Coordinate(0, 8);

            var result = grid.PlaceShip(mockShip.Object, start, Orientation.Horizontal);

            Assert.False(result);
        }        
    }
}