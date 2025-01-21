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

        [Fact]
        public void Shoot_ShouldThrowArgumentOutOfRangeException_WhenCoordinateIsOutOfBounds()
        {
            var grid = new Grid(10);
            var coordinate = new Coordinate(-1, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.Shoot(coordinate));
        }

        [Fact]
        public void Shoot_ShouldReturnMiss_WhenNoShipAtCoordinate()
        {
            var grid = new Grid(10);
            var coordinate = new Coordinate(0, 0);

            var result = grid.Shoot(coordinate);

            Assert.Equal(ShotResult.Miss, result);
        }

        [Fact]
        public void Shoot_ShouldReturnHit_WhenShipIsAtCoordinate()
        {
           var grid = new Grid(10);
            var ship = new Ship("TestShip", 2); 
            grid.PlaceShip(ship, new Coordinate(0, 0), Orientation.Horizontal);
            var coordinate = new Coordinate(0, 0);

            var result = grid.Shoot(coordinate);

            Assert.Equal(ShotResult.Hit, result);
        }

        [Fact]
        public void Shoot_ShouldReturnSink_WhenShipIsHitInEveryPoint()
        {
           var grid = new Grid(10);
            var ship = new Ship("TestShip", 2); 
            grid.PlaceShip(ship, new Coordinate(0, 0), Orientation.Horizontal);
            var firstHitCoordinate  = new Coordinate(0, 0);
            var secondHitCoordinate = new Coordinate(0, 1);

            var result1 = grid.Shoot(firstHitCoordinate);
            var result2 = grid.Shoot(secondHitCoordinate);

            Assert.Equal(ShotResult.Hit, result1); 
            Assert.Equal(ShotResult.Sink, result2); 
        }
     
        [Fact]
        public void IsValidPlacement_ShipAlreadyExistsInCell_ReturnsFalse()
        {
            var grid = new Grid(10);
            var existingShip = new Ship("Destroyer", 3);
            var newShip = new Ship("Submarine", 2);
            var existingShipStart = new Coordinate(2, 2);
            grid.PlaceShip(existingShip, existingShipStart, Orientation.Horizontal); 

            // Test cases for different overlap scenarios:
            // 1. Overlapping start point
            Assert.False(grid.PlaceShip(newShip, new Coordinate(2, 2), Orientation.Vertical));
            // 2. Overlapping middle point (horizontal)
            Assert.False(grid.PlaceShip(newShip, new Coordinate(2, 1), Orientation.Horizontal)); 
            // 3. Overlapping end point (vertical)
            Assert.False(grid.PlaceShip(newShip, new Coordinate(1, 4), Orientation.Vertical));

        }

    }
}