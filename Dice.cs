using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Dice
    {
        int[] dices;

        public Dice(int[] dices)
        {
            this.dices = dices;
        }

        //function which returns an array with two numbers randomly generated between 1 and 6
        public static int[] RollDice(int[] dice)
        {
            Random alea = new Random();
            for (int i = 0; i < dice.Length; i++)
                dice[i] = alea.Next(6) + 1;
            return dice;
        }

        //Funcion that calaculate the sum of the dices
        public static int SumDice(int[] dice)
        {
            int res = dice[0] + dice[1];
            return res;
        }

        //Function which checks if the dices are equalss
        public static Boolean DoubleDice(int[] dice)
        {
            bool doubledice = false;
            if (dice[0] == dice[1])
            {
                doubledice = true;
            }
            return doubledice;
        }
    }
}
