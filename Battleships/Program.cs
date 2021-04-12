using System;

namespace Battleships
{
    class Battleships
    {
        
        static void Main(string[] args)
        {
            Game game = new Game();
            game.FillNewMap();

            Ship battleship = new Ship(5);
            Ship destroyerA = new Ship(4);
            Ship destroyerB = new Ship(4);
            
            battleship.Spawn(game.map);
            destroyerA.Spawn(game.map);
            destroyerB.Spawn(game.map);
            
            while (!game.GameWon())
            {
                game.DrawMap();
                game.ShootTarget(game.GetTarget(Console.ReadLine()));
            }
            Console.WriteLine("Congrats!");
        }

        
    }
}