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
            Console.WriteLine("Le joueur " + name + " est maintenant sur la case numero " + position);
        }

        /// <summary>
        ///  Display the information of money for the player notify
        /// </summary>
        /// <param name="money"></param>
        /// <param name="name"></param>
        public void UpdateMoney(double money, string name)
        {
            Console.WriteLine("Le joueur " + name + " à maintenant " + money + " euro");
        }

    }
}
