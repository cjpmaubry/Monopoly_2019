using System;

namespace Monopoly_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(115, 50);
            Console.SetWindowPosition(0, 0);
            Monopoly();
        }


        /// <summary>
        /// This fonction launches the Monopoly game by creating the View and the Controller (MVC pattern)
        /// </summary>
        static void Monopoly()
        {
            View view = new View();
            Controller controller = new Controller(view);
            controller.LaunchGame();

        }

    }
}
