using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class ObserveDice:IObserverDice
    {
        private string name;


        // Constructor
        public ObserveDice(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Display the information of the value of each dice
        /// </summary>
        /// <param name="dices"></param>
        public void UpdateDiceInfo(int[] dices)
        {
            Console.WriteLine("\nFirst dice :" + dices[0]);
            Console.WriteLine("Second dice :" + dices[1]);

        }

        /// <summary>
        /// Display the information of double dice
        /// </summary>
        public void UpdateDoubleDiceInfo()
        {
            Console.WriteLine("The player did a Double !");
        }

    }
}
