using System;
using System.Collections.Generic;

namespace Battleships
{
    class Program
    {
        private static int MAP_SIZE = 10;
        private static int MAX_NUMBER_OF_HITS = 13;
        private static int hitCounter = 0;
        private static int[,] map = new int[MAP_SIZE,MAP_SIZE];
        

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
            map[4, 7] = 1;
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
                    if(map[j,i] == 2) Console.Write(" O");
                    else if (map[j, i] == 3) Console.Write(" X");
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
                    map[i, j] = 0;
                }
            }
        }

        private static int TransformToColumnNumber(char column) => columnMapper[Char.ToLower(column)];

        private static void GetTargetAndShoot()
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

                if (map[column, row] == 1 || map[column,row] == 3)
                {
                    map[column, row] = 3;
                }
                else
                {
                    map[column, row] = 2;
                }
            }
        }

        private static void CheckTarget()
        {
            
        }
        
        public static bool GameWon() => hitCounter >= MAX_NUMBER_OF_HITS;
    }
}