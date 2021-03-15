namespace Battleships
{
    public class Square
    {
        
    }
    public class Ship : Square
    {
        protected int size;
        public void Spawn()
        {
            
        }
    }

    public class Battleship : Ship
    {
        public Battleship()
        {
            size = 5;
        }
        
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            size = 4;
        }
    }
}