using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Monopoly();
        }


        /// <summary>
        /// This fonction launch the Monopoly game by creating the View and the Controller (MVC pattern)
        /// </summary>
        static void Monopoly()
        {
            View view = new View();
            Controller controller = new Controller(view);
            controller.LaunchGame();

        }

    }
}
