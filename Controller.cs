using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Controller
    {
        Game game;
        View view;

        // Constructor
        public Controller( View view)
        {
            this.view = view;
            view.Presentation();
            this.game = new Game();
            
        }


        /// <summary>
        /// This fonction initialize the view thanks to the information include in the game
        /// </summary>
        public void Initialisation()
        {
            view.DisplayBoard(game.Board,game.Player_list);
        }

        public void UpdateView(int tour)
        {
            view.UpdateDisplayBoard(game.Board, game.Player_list);
        }

        /// <summary>
        /// This fonction is "the main" fonction because it launch the game
        /// </summary>
        public void LaunchGame()
        {
            bool made_a_double;
            int count;
            Initialisation();
            PauseBeforeLaunching();
            Clear();
            // Loop for the turns
            int tour = 0;
            while (EndGame() == false)
            {
                foreach (Player p in game.Player_list)
                {
                    count = 0;
                    made_a_double = false;
                    do
                    {
                        PlayerActionRollDice(p, tour);
                        made_a_double = TurnOfPlayer(p,tour);                   
                        PlayerActionTurn(p,count,made_a_double);
                        //if a player makes a double he can play again
                        if (made_a_double == true)
                        {
                            count++;
                            if(count==3)
                            {
                                //if he makes three doubles in a row he goes to jail
                                game.Board.SendTojail(p);
                                MessageGoToJail();                              
                            }
                        }
                    } while ((made_a_double == true) && (count < 3));
                }
                tour++;
            }
            Winner();
        }

        /// <summary>
        /// This Method manage the turn of a player 
        /// It performs in the right order the requiere methode and view
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool TurnOfPlayer(Player player,int tour)
        {
            bool made_a_double = false;
            //if the player is in jail he must try to escape instead of moving
            //The box effect method in Jail detects on its own when it has to do the TryToEscape
            if(game.Board.PlayerInJail(player) < 4)
            {
                game.LaunchCaseMethode(player.Position, player, game.Board);
            }
            else
            {
                made_a_double = game.Board.Roll();
                int value = game.Board.ValueDice();
                BreakMove();
                int newposition = game.NewPosition(player, value, game.Board);
                UpdateView(tour);
                DisplayBoxDescription(newposition, game.Board);  
                game.LaunchCaseMethode(newposition, player, game.Board);

            }
            return made_a_double;
        }

        /// <summary>
        /// This method call the view for diplaying information ( informs player, he has a new turn)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="tour"></param>
        public void PlayerActionRollDice(Player player,int tour)
        {
            view.AskPlayerforRollDice(player,tour);
        }

        /// <summary>
        /// This method call the view to display end/new turn according the result of the dices. 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="count"></param>
        /// <param name="made_a_double"></param>
        public void PlayerActionTurn(Player player,int count,bool made_a_double)
        {
            if (count!=3 && made_a_double==true)
            {
                view.AskPlayerforNewTurn(player);
            }
            else
            {
                view.AskPlayerforEndTurn(player);
            }
            
        }

        /// <summary>
        /// This method ask to the view a cleaning.
        /// </summary>
        public void Clear()
        {
            view.ClearConsole();
        }

        /// <summary>
        /// This method call the view to ask a little break before launching the game
        /// </summary>
        public void PauseBeforeLaunching()
        {
            view.PauseConsole();
        }

        /// <summary>
        /// This method call the view to ask a break 
        /// </summary>
        public void BreakMove()
        {
            view.BreakBeforeMove();
        }
        /// <summary>
        /// This method call the view to inform player, he goes to jail.
        /// </summary>
        public void MessageGoToJail()
        {
            view.GoToJail();
        }

        /// <summary>
        /// This method takes the desscription of the corresponding box and call the view method to display it.
        /// </summary>
        /// <param name="newposition"></param>
        /// <param name="board"></param>
        public void DisplayBoxDescription(int newposition,Board board)
        {
            string description = board.Gameboard[newposition].ToString();
            view.DisplayDescription(description);
        }


        /// <summary>
        /// This method return treu if it's the end of the game and false if not
        /// It's the end when only on player has money
        /// </summary>
        /// <returns></returns>
        public bool EndGame()
        {
            int count = 0;
            int nbplayer = 0;
            bool res = false;
            foreach (Player p in game.Player_list)
            {
                if (p.Money<0)
                {
                    count++;
                    game.Player_list.Remove(p);
                }
                nbplayer++;
            }
            if (count + 1 == nbplayer)
                res = true;
            return res;
        }


        /// <summary>
        /// This method find the winner of the game ( the player which has still money ) and call the view to display him
        /// </summary>
        public void Winner()
        {
            Player winner;
            foreach (Player p in game.Player_list)
            {
                if (p.Money > 0)
                {
                    winner=p;
                    view.DisplayWinner(winner);
                }
            }
        }


    }
}
