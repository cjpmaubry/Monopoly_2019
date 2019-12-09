using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class View
    {

        /// <summary>
        /// Method to display the board and the position of the player
        /// </summary>
        /// <param name="board">Instance of the board</param>
        /// <param name="list">List of players</param>
        public void DisplayBoard(Board board, List<Player> list)
        {
            //To display the top row of the board
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int j = 0; j < 3; j++)
            {
                for (int i = 20; i <= 30; i++)
                {
                    //To display the top two rows of each box (player 1 and player 2)
                    if (j != 2)
                    {
                        if (i == list[j].Position)
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                        }
                    }
                    //Display for the third row of each box (player 3 and player 4)
                    else
                    {
                        //If there are two players (no player on the bottom row)
                        if (list.Count == 2)
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                        }
                        //If there are three players (player 3 on the bottom row)
                        if (list.Count == 3)
                        {
                            if (i == list[j].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }
                        }
                        //If there are four players (Players 3 and 4 are on the bottom row)
                        if (list.Count == 4)
                        {
                            if (i == list[j].Position && list[j].Position == list[j + 1].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (i == list[j].Position)
                                {
                                    Console.BackgroundColor = board.Gameboard[i].color;
                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    if (i == list[j+1].Position)
                                    {
                                        Console.BackgroundColor = board.Gameboard[i].color;
                                        Console.Write("|   " + Convert.ToString(list[j+1].Id) + "    |");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = board.Gameboard[i].color;
                                        Console.Write("|        |");
                                        Console.ResetColor();
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }





            //Display of the left and right colums of the board
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            

            for (int i = 19; i >= 11; i--)
            {
                Console.BackgroundColor = board.Gameboard[i].color;
                Console.Write("+--------+");
                Console.ResetColor();
                Console.Write("                                                                                          ");
                Console.BackgroundColor = board.Gameboard[i].color;
                Console.WriteLine("+--------+");
                Console.ResetColor();
                for (int j = 0; j < 3; j++)
                {
                    //Display for the two top rows of each box
                    if (j != 2)
                    {
                        //Display if a player is on a box on the left column
                        if (i == list[j].Position)
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                            Console.ResetColor();
                            Console.Write("                                                                                          ");
                            Console.BackgroundColor = board.Gameboard[50 - i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }
                        else
                        {
                            if (50 - i == list[j].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                                Console.Write("                                                                                          ");
                                Console.BackgroundColor = board.Gameboard[50 - i].color;
                                Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                Console.ResetColor();
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                                Console.Write("                                                                                          ");
                                Console.BackgroundColor = board.Gameboard[50 - i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                                Console.WriteLine("");
                            }
                        }
                    }
                    //Display for the third row of each box
                    else
                    {
                        //If there are two players (no player on the third row of the box)
                        if (list.Count == 2)
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                            Console.Write("                                                                                          ");
                            Console.BackgroundColor = board.Gameboard[50 - i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }
                        //If there are three players (player 3 on the third row) 
                        if (list.Count == 3)
                        {
                            if (i == list[j].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                Console.ResetColor();
                                Console.Write("                                                                                          ");
                                Console.BackgroundColor = board.Gameboard[50 - i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                                Console.WriteLine("");
                            }
                            else
                            {
                                //If there is a player on a box on the right column
                                if (50 - i == list[j].Position)
                                {
                                    Console.BackgroundColor = board.Gameboard[i].color;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                    Console.Write("                                                                                          ");
                                    Console.BackgroundColor = board.Gameboard[50 - i].color;
                                    Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                    Console.ResetColor();
                                    Console.WriteLine("");
                                }
                                //If there is no player on both colums
                                else
                                {
                                    Console.BackgroundColor = board.Gameboard[i].color;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                    Console.Write("                                                                                          ");
                                    Console.BackgroundColor = board.Gameboard[50 - i].color;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                    Console.WriteLine("");
                                }
                            }
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("+--------+");
                            Console.ResetColor();
                            Console.Write("                                                                                          ");
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("+--------+");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }


                        if (list.Count == 4)
                        {
                            //If player 3 and player 4 are on the same box on the left column
                            if (i == list[j].Position && i == list[j + 1].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                Console.ResetColor();
                                Console.Write("                                                                                          ");
                                Console.BackgroundColor = board.Gameboard[50 - i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                                Console.WriteLine("");
                            }
                            else
                            {
                                //If player 3 and player 4 are on the same box on the right column
                                if (50 - i == list[j].Position && 50 - i == list[j + 1].Position)
                                {
                                    Console.BackgroundColor = board.Gameboard[i].color;
                                    Console.WriteLine("|        |");
                                    Console.ResetColor();
                                    Console.Write("                                                                                          ");
                                    Console.BackgroundColor = board.Gameboard[50 - i].color;
                                    Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                    Console.ResetColor();
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    //If player 3 is on a box on the left column
                                    if (i == list[j].Position)
                                    {
                                        Console.BackgroundColor = board.Gameboard[i].color;
                                        Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                        Console.ResetColor();
                                        Console.Write("                                                                                          ");
                                        Console.BackgroundColor = board.Gameboard[50 - i].color;
                                        Console.Write("|        |");
                                        Console.ResetColor();
                                        Console.WriteLine("");
                                    }
                                    else
                                    {
                                        //If player 3 is on a box on the right column
                                        if (50 - i == list[j].Position)
                                        {
                                            Console.BackgroundColor = board.Gameboard[i].color;
                                            Console.Write("|        |");
                                            Console.ResetColor();
                                            Console.Write("                                                                                          ");
                                            Console.BackgroundColor = board.Gameboard[50 - i].color;
                                            Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                            Console.ResetColor();
                                            Console.WriteLine("");
                                        }
                                        else
                                        {
                                            //If player 4 is on a box on the left column
                                            if (i == list[j + 1].Position)
                                            {
                                                Console.BackgroundColor = board.Gameboard[i].color;
                                                Console.Write("|    " + Convert.ToString(list[j + 1].Id) + "   |");
                                                Console.ResetColor();
                                                Console.Write("                                                                                          ");
                                                Console.BackgroundColor = board.Gameboard[50 - i].color;
                                                Console.Write("|        |");
                                                Console.ResetColor();
                                                Console.WriteLine("");
                                            }
                                            else
                                            {
                                                //If player 4 is on a box on the right column
                                                if (50 - i == list[j + 1].Position)
                                                {
                                                    Console.BackgroundColor = board.Gameboard[i].color;
                                                    Console.Write("|        |");
                                                    Console.ResetColor();
                                                    Console.Write("                                                                                          ");
                                                    Console.BackgroundColor = board.Gameboard[50 - i].color;
                                                    Console.Write("|    " + Convert.ToString(list[j + 1].Id) + "   |");
                                                    Console.ResetColor();
                                                    Console.WriteLine("");
                                                }
                                                //If there is no player on both colums
                                                else
                                                {

                                                    Console.BackgroundColor = board.Gameboard[i].color;
                                                    Console.Write("|        |");
                                                    Console.ResetColor();
                                                    Console.Write("                                                                                          ");
                                                    Console.BackgroundColor = board.Gameboard[50 - i].color;
                                                    Console.Write("|        |");
                                                    Console.ResetColor();
                                                    Console.WriteLine("");
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


            //Display of the bottom row
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int j = 0; j < 3; j++)
            {
                for (int i = 10; i >= 0; i--)
                {
                    //To display the top two rows of each box (player 1 and player 2)
                    if (j != 2)
                    {
                        if (i == list[j].Position)
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                        }
                    }
                    //Display for the third row of each box (player 3 and player 4)
                    else
                    {
                        //If there are two players (no player on the bottom row)
                        if (list.Count == 2)
                        {
                            Console.BackgroundColor = board.Gameboard[i].color;
                            Console.Write("|        |");
                            Console.ResetColor();
                        }
                        //If there are three players (player 3 on the bottom row)
                        if (list.Count == 3)
                        {
                            if (i == list[j].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }
                        }
                        //If there are four players (Players 3 and 4 are on the bottom row)
                        if (list.Count == 4)
                        {
                            if (i == list[j].Position && list[j].Position == list[j + 1].Position)
                            {
                                Console.BackgroundColor = board.Gameboard[i].color;
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (i == list[j].Position)
                                {
                                    Console.BackgroundColor = board.Gameboard[i].color;
                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    if (i == list[j + 1].Position)
                                    {
                                        Console.BackgroundColor = board.Gameboard[i].color;
                                        Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = board.Gameboard[i].color;
                                        Console.Write("|        |");
                                        Console.ResetColor();
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


        /// <summary>
        /// Method to display the board and the position of the player with the update
        /// </summary>
        /// <param name="board"></param>
        /// <param name="list"></param>
        public void UpdateDisplayBoard(Board board, List<Player> list)
        {           
            DisplayBoard(board, list);
        }

        /// <summary>
        /// Method to display information for player ( informs player it's his turn) ank ask for rolling dice
        /// </summary>
        /// <param name="player"></param>
        /// <param name="tour"></param>
        public void AskPlayerforRollDice(Player player,int tour)
        {
        Console.WriteLine("TURN NUMBER " + (tour + 1));
        Console.WriteLine("\nTurn of player "+player.Id + " : " + player.Name);
        Console.WriteLine("Press any key to roll the dices");
        Console.ReadKey();
        }

        /// <summary>
        ///  Method to display information for player ( informs player his turn is finish) and ask to end turn
        /// </summary>
        /// <param name="player"></param>
        public void AskPlayerforEndTurn(Player player)
        {
            Console.WriteLine("Press any key to finish your turn");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        ///  Method to display information for player ( informs player, he has a new turn) and ask to begin turn
        /// </summary>
        /// <param name="player"></param>
        public void AskPlayerforNewTurn(Player player)
        {
            Console.WriteLine("Press any key to start your new turn");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Method which clean console
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }

        /// <summary>
        /// Method that allows pause time in console
        /// </summary>
        public void PauseConsole()
        {
            Console.WriteLine("\nGame will start in 3 secondes");
            Console.Write("===3");
            System.Threading.Thread.Sleep(1000);
            Console.Write("===2");
            System.Threading.Thread.Sleep(1000);
            Console.Write("===1");
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// Method which ask player before move
        /// </summary>
        public void BreakBeforeMove()
        {
            Console.WriteLine("Press any key to move");
            Console.ReadKey();
        }

        /// <summary>
        /// Method that inform player he is in jail because of too much doubles 
        /// </summary>
        public void GoToJail()
        {
            Console.WriteLine("Too much doubles ! You got sent to jail");
        }

        /// <summary>
        /// Method that display the description of the box which are given in parametre
        /// </summary>
        /// <param name="description"></param>
        public void DisplayDescription(string description)
        {
            Console.WriteLine(description);
        }

        public void Presentation()
        {
            string space = "                                  ";
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine(space+"  /\\/\\   ___  _ __   ___  _ __   ___ | |_   _ ");
            Console.WriteLine(space + " /    \\ / _ \\| '_ \\ / _ \\| '_ \\ / _ \\| | | | |");
            Console.WriteLine(space + "/ /\\/\\ \\ (_) | | | | (_) | |_) | (_) | | |_| |");
            Console.WriteLine(space + "\\/    \\/\\___/|_| |_|\\___/| .__/ \\___/|_|\\__, |");
            Console.WriteLine(space + "                         |_|            |___/ ");
            System.Threading.Thread.Sleep(2500);
            Console.Clear();
        }

    }
}
