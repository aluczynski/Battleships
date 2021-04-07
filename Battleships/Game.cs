using System;
using System.Collections.Generic;

namespace Battleships
{
    public class Game
    {
        public static int MAP_SIZE = 10;
        public static int MAX_NUMBER_OF_HITS = 13;
        private int score = 0;
        public State[,] map = new State[MAP_SIZE,MAP_SIZE];
        
        
        private Dictionary<char, int> columnMapper = new Dictionary<char, int>()
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
        public void DrawMap()
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
                    else Console.Write(" .");
                }

                Console.WriteLine();
            }
        }
        
        public void FillNewMap()
        {
            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    map[i, j] = State.Water;
                }
            }
        }

        private  int TransformToColumnNumber(char column) => columnMapper[Char.ToLower(column)];

        public void GetTargetAndShoot() => ShootTarget(GetTarget());

        private int[] GetTarget()
        {
            char[] inputChars = Console.ReadLine().ToCharArray();
            if (inputChars.Length > 2)
            {
                Console.WriteLine("Invalid entry");
            }
            
            int[] inputNumeric = new int[2];
            inputNumeric[0] = TransformToColumnNumber(inputChars[0]);
            inputNumeric[1]= (int)Char.GetNumericValue(inputChars[1]);

            return inputNumeric;
        }

        public void ShootTarget(int[] targetCoordinates)
        {
            int column = targetCoordinates[0];
            int row = targetCoordinates[1];

            if (map[column, row] == State.HiddenShip || map[column,row] == State.Hit)
            {
                if (map[column, row] == State.HiddenShip) IncreaseScore(1);
                map[column, row] = State.Hit;
            }
            else
            {
                map[column, row] = State.Miss;
            }
            
        }
        
        public bool GameWon() => score >= MAX_NUMBER_OF_HITS;

        public void IncreaseScore(int increaseBy) => score += increaseBy;
        public int ReturnScore() => score;
    }
}