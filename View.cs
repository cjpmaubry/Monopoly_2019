using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class View
    {
        public void Display(Game game)
        {
            Console.WriteLine("MONOPOLY");


        }

        public void DisplayBoard(Board board)
        {
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            int compt = 0;
            while (compt < 3)
            {
                for (int i = 20; i <= 30; i++)
                {
                    if (board.gameboard[i].box_description == "neutral")
                    {
                        Console.Write("|        |");
                    }
                    if (board.gameboard[i].box_description == "gotojail")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|        |");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                compt++;
            }
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");

            for (int i = 19; i >= 11; i--)
            {
                if (board.gameboard[i].box_description == "neutral" && board.gameboard[50 - i].box_description == "neutral")
                {
                    Console.Write("+--------+");
                    Console.WriteLine("                                                                                          +--------+");
                    Console.Write("|        |");
                    Console.WriteLine("                                                                                          |        |");
                    Console.Write("|        |");
                    Console.WriteLine("                                                                                          |        |");
                    Console.Write("|        |");
                    Console.WriteLine("                                                                                          |        |");
                    Console.Write("+--------+");
                    Console.WriteLine("                                                                                          +--------+");
                }
            }

            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            int compt2 = 0;
            while (compt2 < 3)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (board.gameboard[i].box_description == "neutral")
                    {
                        Console.Write("|        |");
                    }
                    if (board.gameboard[i].box_description == "jail")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|        |");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                compt2++;
            }
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
        }
    }
}