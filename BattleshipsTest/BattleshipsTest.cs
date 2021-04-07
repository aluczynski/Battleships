using System;
using Xunit;

namespace Battleships
{
    public class BattleshipsTestSuite
    {
        private State[,] map = new State[10, 10];
        [Fact]
        public void PlacementNotPossibleWhenShipPlacedOutOfMap()
        {
            Ship ship = new Ship(4);

            Assert.False(ship.IsShipPlacementPossible(8, 8, Direction.Horizontal, map));
        }

        [Fact]
        public void ReturnsInvalidInputWhenUsedMoreThanTwoCharactersToShoot()
        {
            
        }
    }
}