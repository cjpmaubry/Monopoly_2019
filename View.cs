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
                        //Display a red background for the gotojail Box
                        if (board.Gameboard[i].box_description == "gotojail")
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("|        |");
                            Console.ResetColor();
                        }
                        else
                        {
                            //Display if there is a player on a neutral box
                            if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                            {
                                Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                            }
                            //Display if there is no player on a neutral box 
                            else
                            {
                                Console.Write("|        |");
                            }
                        }
                    }
                    //Display for the third row of each box (player 3 and player 4)
                    else
                    {
                        //If there are two players (no player on the bottom row)
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
                        //If there are three players (player 3 on the bottom row)
                        if (list.Count == 3)
                        {
                            if (board.Gameboard[i].box_description == "gotojail")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }
                            else
                            {
                                //If the player is on a neutral box
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                {
                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                }
                                //If the player is not on a neutral box
                                else
                                {
                                    Console.Write("|        |");
                                }
                            }
                        }
                        //If there are four players (Players 3 and 4 are on the bottom row)
                        if (list.Count == 4)
                        {
                            //Display when player 3 and player 4 are on the same box
                            if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                            {
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                            }
                            else
                            {
                                //Display for the gotojail box
                                if (board.Gameboard[i].box_description == "gotojail")
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    //Display if player 3 is on a neutral box
                                    if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                    {
                                        Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                    }
                                    else
                                    {
                                        //Display if player 4 is on a neutral box
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
                Console.WriteLine();
            }
            //Display of the left and right colums of the board
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int i = 19; i >= 11; i--)
            {
                //Display if the two boxes opposite to each other are neutral
                if (board.Gameboard[i].box_description == "neutral" && board.Gameboard[50 - i].box_description == "neutral")
                {
                    Console.Write("+--------+");
                    Console.WriteLine("                                                                                          +--------+");
                    for (int j = 0; j < 3; j++)
                    {
                        //Display for the two top rows of each box
                        if (j != 2)
                        {
                            //Display if a player is on a box on the left column
                            if (i == list[j].Position)
                            {
                                Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                Console.WriteLine("                                                                                          |        |");
                            }
                            else
                            {
                                //Display if a player is on a box on the left column
                                if (50 - i == list[j].Position)
                                {
                                    Console.Write("|        |");
                                    Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j].Id) + "   |");
                                }
                                //Display if there is no player on opposite boxes in the colums
                                else
                                {
                                    Console.Write("|        |");
                                    Console.WriteLine("                                                                                          |        |");
                                }
                            }
                        }
                        //Display for the third row of each box
                        else
                        {
                            //If there are two players (no player on the third row of the box)
                            if (list.Count == 2)
                            {
                                Console.Write("|        |");
                                Console.WriteLine("                                                                                          |        |");
                            }
                            //If there are three players (player 3 on the third row) 
                            if (list.Count == 3)
                            {
                                //If there is a player on a box on the left column
                                if (i == list[j].Position)
                                {
                                    Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                    Console.WriteLine("                                                                                          |        |");
                                }
                                else
                                {
                                    //If there is a player on a box on the right column
                                    if (50 - i == list[j].Position)
                                    {
                                        Console.Write("|        |");
                                        Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j].Id) + "   |");
                                    }
                                    //If there is no player on both colums
                                    else
                                    {
                                        Console.Write("|        |");
                                        Console.WriteLine("                                                                                          |        |");
                                    }
                                }
                            }
                            //If there are four players (player 3 and player four on the third row) 
                            if (list.Count == 4)
                            {
                                //If player 3 and player 4 are on the same box on the left column
                                if (i == list[j].Position && i == list[j + 1].Position)
                                {
                                    Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                    Console.WriteLine("                                                                                          |        |");
                                }
                                else
                                {
                                    //If player 3 and player 4 are on the same box on the right column
                                    if (50 - i == list[j].Position && 50 - i == list[j + 1].Position)
                                    {
                                        Console.Write("|        |");
                                        Console.WriteLine("                                                                                          |  "
                                            + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                    }
                                    else
                                    {
                                        //If player 3 is on a box on the left column
                                        if (i == list[j].Position)
                                        {
                                            Console.Write("|    " + Convert.ToString(list[j].Id) + "   |");
                                            Console.WriteLine("                                                                                          |        |");
                                        }
                                        else
                                        {
                                            //If player 3 is on a box on the right column
                                            if (50 - i == list[j].Position)
                                            {
                                                Console.Write("|        |");
                                                Console.WriteLine("                                                                                          |    " + Convert.ToString(list[j].Id) + "   |");
                                            }
                                            else
                                            {
                                                //If player 4 is on a box on the left column
                                                if (i == list[j + 1].Position)
                                                {
                                                    Console.Write("|    " + Convert.ToString(list[j + 1].Id) + "   |");
                                                    Console.WriteLine("                                                                                          |        |");
                                                }
                                                else
                                                {
                                                    //If player 4 is on a box on the right column
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
            //Display of the bottom row
            Console.WriteLine("+--------++--------++--------++--------++--------++--------++--------++--------++--------++--------++--------+");
            for (int j = 0; j < 3; j++)
            {
                for (int i = 10; i >= 0; i--)
                {
                    //Display of the top two rows of each box (player 1 and player 2)
                    if (j != 2)
                    {
                        //Display if there is a player on the jail box (red background)
                        if (board.Gameboard[i].box_description == "jail" && i == list[j].Position)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                            Console.ResetColor();
                        }
                        else
                        {
                            //Display if there is no player on the jail box
                            if (board.Gameboard[i].box_description == "jail")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|        |");
                                Console.ResetColor();
                            }
                            else
                            {
                                //Display if there is a player on a neutral box
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                {
                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                }
                                //Display if there is no player on a neutral box
                                else
                                {
                                    Console.Write("|        |");
                                }
                            }
                        }
                    }
                    else
                    {
                        //If there are two players (no player on the third row of the box)
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
                        //If there are three players (player 3 on the third row) 
                        if (list.Count == 3)
                        {
                            //If the player is on the jail box
                            if (board.Gameboard[i].box_description == "jail" && i == list[j].Position)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                Console.ResetColor();
                            }
                            else
                            {
                                //If there is no player on the jail box
                                if (board.Gameboard[i].box_description == "jail")
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("|        |");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    //If the player is on a neutral box
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
                        //If there are four players (player 3 and player four on the third row) 
                        if (list.Count == 4)
                        {
                            //If the two players are on the jail box
                            if (board.Gameboard[i].box_description == "jail" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                Console.ResetColor();
                            }
                            else
                            {
                                //If the two players are on the same neutral box
                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position && list[j].Position == list[j + 1].Position)
                                {
                                    Console.Write("|  " + Convert.ToString(list[j].Id) + "  " + Convert.ToString(list[j + 1].Id) + "  |");
                                }
                                else
                                {
                                    //if only player 3 is on the jail box
                                    if (board.Gameboard[i].box_description == "jail" && i == list[j].Position)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        //if only player 4 is on the jail box
                                        if (board.Gameboard[i].box_description == "jail" && i == list[j + 1].Position)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            //If there is no player on the jail box
                                            if (board.Gameboard[i].box_description == "jail")
                                            {
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.Write("|        |");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                //If only player 3 is on a neutal box
                                                if (board.Gameboard[i].box_description == "neutral" && i == list[j].Position)
                                                {
                                                    Console.Write("|   " + Convert.ToString(list[j].Id) + "    |");
                                                }
                                                else
                                                {
                                                    //If only player 4 is on a neutral box
                                                    if (board.Gameboard[i].box_description == "neutral" && i == list[j + 1].Position)
                                                    {
                                                        Console.Write("|   " + Convert.ToString(list[j + 1].Id) + "    |");
                                                    }
                                                    //If there is no payer on a neutral box
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

    }
}
