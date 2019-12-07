using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class View
    {

        public void DisplayBoard(Board board, List<Player> list)
        {

            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int j = 0; j < 3; j++)
            {
                for (int i = 20; i <= 30; i++)
                {
                    if (j != 2)
                    {
                        if (board.Gameboard[i].box_description == "gotojail" && i == list[j].Position)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                            Console.ResetColor();
                        }
                        else
                        {
                            if (board.Gameboard[i].box_description == "gotojail")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                {
                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                }
                                else
                                {
                                    Console.Write("|        |");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (list.Count == 2)
                        {
                            if (board.Gameboard[i].box_description == "gotojail")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }

                            else
                            {
                                if (board.Gameboard[i].box_description == "neutral")
                                {
                                    Console.Write("|        |");
                                }
                            }
                        }
                        if (list.Count == 3)
                        {
                            if (board.Gameboard[i].box_description == "gotojail" && i == list[j].Position)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (board.Gameboard[i].box_description == "gotojail")
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                    {
                                        Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                    }
                                    else
                                    {
                                        Console.Write("|        |");
                                    }
                                }
                            }
                        }
                        if (list.Count == 4)
                        {
                            if (board.Gameboard[i].box_description == "gotojail" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                                {
                                    Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                }
                                else
                                {
                                    if (board.Gameboard[i].box_description == "gotojail" && i == list[j].Position)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        if (board.Gameboard[i].box_description == "gotojail" && i == list[j + 1].Position)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            if (board.Gameboard[i].box_description == "gotojail")
                                            {
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.Write("|        |");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                                {
                                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                                }
                                                else
                                                {
                                                    if (board.Gameboard[i].box_description == "neutral" && i == list[j + 1].Position)
                                                    {
                                                        Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                                    }
                                                    else
                                                    {
                                                        Console.Write("|        |");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int i = 19; i >= 11; i--)
            {
                if (board.Gameboard[i].box_description == "neutral" && board.Gameboard[50 - i].box_description == "neutral")
                {
                    Console.Write("+--------+");
                    Console.WriteLine("                                                                                          +--------+");
                    for (int j = 0; j < 3; j++)
                    {
                        if (j != 2)
                        {
                            if (i == list[j].Position)
                            {
                                Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                Console.WriteLine("                                                                                          |        |");
                            }
                            else
                            {
                                if (50 - i == list[j].Position)
                                {
                                    Console.Write("|        |");
                                    Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j].Id) + "   |");
                                }
                                else
                                {
                                    Console.Write("|        |");
                                    Console.WriteLine("                                                                                          |        |");
                                }
                            }
                        }
                        else
                        {
                            if (list.Count == 2)
                            {
                                Console.Write("|        |");
                                Console.WriteLine("                                                                                          |        |");
                            }
                            if (list.Count == 3)
                            {
                                if (i == list[j].Position)
                                {
                                    Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                    Console.WriteLine("                                                                                          |        |");
                                }
                                else
                                {
                                    if (50 - i == list[j].Position)
                                    {
                                        Console.Write("|        |");
                                        Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j].Id) + "   |");
                                    }
                                    else
                                    {
                                        Console.Write("|        |");
                                        Console.WriteLine("                                                                                          |        |");
                                    }
                                }
                            }
                            if (list.Count == 4)
                            {
                                if (i == list[j].Position && i == list[j + 1].Position)
                                {
                                    Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                    Console.WriteLine("                                                                                          |        |");
                                }
                                else
                                {
                                    if (50 - i == list[j].Position && 50 - i == list[j + 1].Position)
                                    {
                                        Console.Write("|        |");
                                        Console.WriteLine("                                                                                          |  "
                                            + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                    }
                                    else
                                    {
                                        if (i == list[j].Position)
                                        {
                                            Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                            Console.WriteLine("                                                                                          |        |");
                                        }
                                        else
                                        {
                                            if (50 - i == list[j].Position)
                                            {
                                                Console.Write("|        |");
                                                Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j].Id) + "   |");
                                            }
                                            else
                                            {
                                                if (i == list[j + 1].Position)
                                                {
                                                    Console.Write("|    " + Convert.ToString(list[j + 1].Id) + "   |");
                                                    Console.WriteLine("                                                                                          |        |");
                                                }
                                                else
                                                {
                                                    if (50 - i == list[j + 1].Position)
                                                    {
                                                        Console.Write("|        |");
                                                        Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j + 1].Id) + "   |");
                                                    }
                                                    else
                                                    {
                                                        Console.Write("|        |");
                                                        Console.WriteLine("                                                                                          |        |");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.Write("+--------+");
                    Console.WriteLine("                                                                                          +--------+");
                }
            }
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int j = 0; j < 3; j++)
            {
                for (int i = 10; i >= 0; i--)
                {
                    if (j != 2)
                    {
                        if (board.Gameboard[i].box_description == "jail" && i == list[j].Position)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                            Console.ResetColor();
                        }
                        else
                        {
                            if (board.Gameboard[i].box_description == "jail")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                {
                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                }
                                else
                                {
                                    Console.Write("|        |");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (list.Count == 2)
                        {
                            if (board.Gameboard[i].box_description == "jail")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }

                            else
                            {
                                if (board.Gameboard[i].box_description == "neutral")
                                {
                                    Console.Write("|        |");
                                }
                            }
                        }
                        if (list.Count == 3)
                        {
                            if (board.Gameboard[i].box_description == "jail" && i == list[j].Position)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (board.Gameboard[i].box_description == "jail")
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                    {
                                        Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                    }
                                    else
                                    {
                                        Console.Write("|        |");
                                    }
                                }
                            }
                        }
                        if (list.Count == 4)
                        {
                            if (board.Gameboard[i].box_description == "jail" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                                {
                                    Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                }
                                else
                                {
                                    if (board.Gameboard[i].box_description == "jail" && i == list[j].Position)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        if (board.Gameboard[i].box_description == "jail" && i == list[j + 1].Position)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            if (board.Gameboard[i].box_description == "jail")
                                            {
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.Write("|        |");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                                {
                                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                                }
                                                else
                                                {
                                                    if (board.Gameboard[i].box_description == "neutral" && i == list[j + 1].Position)
                                                    {
                                                        Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                                    }
                                                    else
                                                    {
                                                        Console.Write("|        |");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
        }


        public void UpdateDisplayBoard(Board board, List<Player> list, int tour)
        {           
            Console.WriteLine("Tour numéro " + tour);
            DisplayBoard(board, list);
        }


        public void AskPlayerforAction(Player player)
        {
        Console.WriteLine("Turn of player "+player.Name);
        Console.WriteLine("Press a key to launch dice");
        Console.ReadKey();
        }


        public void AskPlayerforAction2(Player player)
        {
            Console.WriteLine("Press a key to finish your turn");
            Console.ReadKey();
            Console.Clear();
        }


        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
