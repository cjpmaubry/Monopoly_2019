using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class ObservePlayer : IObserver
    {

        private string name;


        // Constructor

        public ObservePlayer(string name)
        {
            this.name = name;
        }


        /// <summary>
        /// Display the information of position for the player notify
        /// </summary>
        /// <param name="position"></param>
        /// <param name="name"></param>
        public void UpdatePosition(int position, string name)
        {
            Console.WriteLine("The player " + name + " is now at position " + position);
        }

        /// <summary>
        ///  Display the information of money for the player notify
        /// </summary>
        /// <param name="money"></param>
        /// <param name="name"></param>
        public void UpdateMoney(double money, string name)
        {
            Console.WriteLine("The player " + name + " has now " + money + " M");
        }

        /// <summary>
        ///  Display the information of property for the player notify
        /// </summary>
        /// <param name="propreties"></param>
        /// <param name="board"></param>
        public void UpdateProperty(List<Abs_Box> propreties, Board board)
        {
            string message = null;
            foreach(Abs_Box owned in propreties)
            {
                message += owned.ToString();
            }
            Console.WriteLine(message);
        }

    }
}
