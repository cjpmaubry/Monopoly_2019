using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Dice
    {
        private int[] dices;

        public Dice()
        {
            this.dices = new int[2];
        }

        //Function which returns an array with two numbers randomly generated between 1 and 6
        public void RollDice()
        {
            Random alea = new Random();
            dices[0] = alea.Next(0, 7);
            dices[1] = alea.Next(0, 7);      
        }

        //Function that calaculate the sum of the dices
        //Returns the value of the sum
        public int SumDice()
        {
            int res = dices[0] + dices[1];
            return res;
        }

        //Function which checks if the dices are equal
        //Return true if they are
        public bool DoubleDice()
        {
            bool doubledice = false;
            if (dices[0] == dices[1])
            {
                doubledice = true;
            }
            return doubledice;
        }
    }
}
