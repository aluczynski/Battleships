using System;
using Xunit;

namespace Battleships
{
    public class BattleshipsTestSuite
    {
        [Fact]
        public void PlacementNotPossibleWhenShipPlacedOutOfMap()
        {
            Game game = new Game();
            Ship ship = new Ship(4);

            Assert.True(ship.ShipPlacementNotPossible(8, 8, Direction.Horizontal, game.map));
        }

        [Fact]
        public void ThrowsExceptionWhenInvalidInput()
        {
            Game game = new Game();
            
        }

        [Fact]
        public void GameIsWonWhenScoreAboveOrEqualMaxScore()
        {
            Game game = new Game();
            game.IncreaseScore(13);
            Assert.True(game.GameWon());
        }

        [Fact]
        public void MarkAsHitWhenHiddenShipShot()
        {
            Game game = new Game();
            game.map[0, 0] = State.HiddenShip;
            int[] target = {0, 0};
            game.ShootTarget(target);
            Assert.Equal(State.Hit,game.map[0,0]);
        }

        [Fact]
        public void PlaceShipWhenDetailsAvailable()
        {
            Game game = new Game();
            Ship ship = new Ship(4);

            int shipFieldCounter = 0;
            ship.Spawn(game.map);
            
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.map[j, i] == State.HiddenShip)
                    {
                        shipFieldCounter++;
                    }
                }
            }
            
            Assert.Equal(4,shipFieldCounter);
        }
    }
}