using System;

namespace Battleships
{

    public class Ship
    {
        protected int size;
        static readonly Random rand = new Random();
        
        public Ship(int size)
        {
            this.size = size;
        }
        
        public void Spawn(State[,] map)
        {
            int row;
            int column;
            Direction direction;
            
            do
            {
                row = RandomAvailableNumber();
                column = RandomAvailableNumber();
                direction = RandomDirection();
            } while (!IsShipPlacementPossible(row, column, direction, map));

            if (direction == Direction.Horizontal)
            {
                for (int i = 0; i < size; i++)
                {
                    map[row, column + i] = State.HiddenShip;
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    map[row + i, column] = State.HiddenShip;
                }
            }

        }

        public bool IsShipPlacementPossible(int row,int col,Direction direction,State[,] map)
        {
            if (!IsShipPlacementOutOfMap(row, col, direction)) return false;
            return IsShipPlacementInterferingWithOtherShip(row, col, direction, map);
        }

        private bool IsShipPlacementOutOfMap(int row, int column, Direction direction)
        {
            return direction == Direction.Horizontal
                ? column + size <= Battleships.MAP_SIZE
                : row + size <= Battleships.MAP_SIZE;
        }

        private bool IsShipPlacementInterferingWithOtherShip(int row,int col,Direction direction,State[,] map)
        {
            if (direction == Direction.Horizontal)
            {
                for (int i = 0; i < size; i++)
                {
                    if (map[row, col + i] == State.HiddenShip) return true;
                }

                return false;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (map[row + i, col] == State.HiddenShip) return true;
                }

                return false;
            }
        }
        
        
        private int RandomAvailableNumber()
        {
            int randomNumber = rand.Next(0, Battleships.MAP_SIZE);
            return randomNumber;
        }

        private Direction RandomDirection()
        {
            int randomNumber = rand.Next(1,2);
            return randomNumber == 1 ? Direction.Horizontal : Direction.Vertical;
        }
    }
}