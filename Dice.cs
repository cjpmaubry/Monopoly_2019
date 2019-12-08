using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Dice:ISubjectDice
    {
        private int[] dices;
        private ObserveDice observer;

        public Dice()
        {        
            this.dices = new int[2];
        }

        /// <summary>
        /// Function which returns an array with two numbers randomly generated between 1 and 6
        /// </summary>
        public bool RollDice()
        {
            Random alea = new Random();
            dices[0] = alea.Next(1, 7);
            dices[1] = alea.Next(1, 7);
            NotifyDice(dices);
            bool res=DoubleDice();
            return res;
        }


        /// <summary>
        /// Function that calaculate the sum of the dices
        /// </summary>
        /// <returns>
        /// Returns the value of the sum
        /// </returns>
        public int SumDice()
        {
            int res = dices[0] + dices[1];
            return res;
        }


        /// <summary>
        /// Function which checks if the dices are equal
        /// </summary>
        /// <returns>
        /// Return true if they are
        /// </returns>
        public bool DoubleDice()
        {
            bool doubledice = false;
            if (dices[0] == dices[1])
            {
                doubledice = true;
                NotifyDoubleDice();
            }
            return doubledice;
        }

        /// <summary>
        /// Allow the posibility to attach an observer
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(ObserveDice observer)
        {
            this.observer = observer;
        }


        /// <summary>
        /// Allow the posibility to detach an observer
        /// </summary>
        /// <param name="observer"></param>

        public void Detach(ObserveDice observer)
        {
            this.observer = observer;
        }

        /// <summary>
        /// Notify if a player make a double dice
        /// </summary>
        public void NotifyDoubleDice()
        {
            observer.UpdateDoubleDiceInfo();
        }

        /// <summary>
        ///  Notify the Dice value
        /// </summary>
        /// <param name="dices"></param>
        public void NotifyDice(int[] dices)
        {
            observer.UpdateDiceInfo(dices);
        }


    }
}
