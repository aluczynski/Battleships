using System;
using System.Collections.Generic;

namespace Battleships
{
    class Battleships
    {
        public static int MAP_SIZE = 10;
        public static int MAX_NUMBER_OF_HITS = 13;
        public static int score = 0;
        public static State[,] map = new State[MAP_SIZE,MAP_SIZE];
        
        
        private static Dictionary<char, int> columnMapper = new Dictionary<char, int>()
        {
            {'a',0},
            {'b',1},
            {'c',2},
            {'d',3},
            {'e',4},
            {'f',5},
            {'g',6},
            {'h',7},
            {'i',8},
            {'j',9}
        };
        
        static void Main(string[] args)
        {
            FillNewMap();

            Ship battleship = new Ship(5);
            Ship destroyerA = new Ship(4);
            Ship destroyerB = new Ship(4);
            
            battleship.Spawn(map);
            destroyerA.Spawn(map);
            destroyerB.Spawn(map);
            
            while (!GameWon())
            {
                DrawMap();
                GetTargetAndShoot();
            }
            Console.WriteLine("Congrats!");
        }

        private static void DrawMap()
        {
            string columnHeaders = "   A B C D E F G H I J";

            Console.WriteLine(columnHeaders);

            for (int i = 0; i < MAP_SIZE; i++)
            {
                Console.Write($"{i}|");
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    //TODO change to switch/dictionary
                    if(map[j,i] == State.Miss) Console.Write(" O");
                    else if (map[j, i] == State.Hit) Console.Write(" X");
                    else if (map[j,i] == State.HiddenShip) Console.Write(" Z");
                    else Console.Write(" .");
                }

                Console.WriteLine();
            }
        }
        
        private static void FillNewMap()
        {
            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    map[i, j] = State.Water;
                }
            }
        }

        private static int TransformToColumnNumber(char column) => columnMapper[Char.ToLower(column)];

        public static void GetTargetAndShoot()
        {
            char[] input = Console.ReadLine().ToCharArray();
            if (input.Length > 2)
            {
                Console.WriteLine("Invalid entry");
            }
            else
            {
                int column = TransformToColumnNumber(input[0]);
                int row = (int)Char.GetNumericValue(input[1]);

                if (map[column, row] == State.HiddenShip || map[column,row] == State.Hit)
                {
                    if (map[column, row] == State.HiddenShip) score++;
                    map[column, row] = State.Hit;
                }
                else
                {
                    map[column, row] = State.Miss;
                }
            }
        }
        
        public static bool GameWon() => score >= MAX_NUMBER_OF_HITS;

        public static void IncreaseScore(int increaseBy) => score += increaseBy;
        public static int ReturnScore() => score;
    }
}