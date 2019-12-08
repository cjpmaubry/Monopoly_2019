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
            this.game = new Game();
            this.view = view;
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
            Initialisation();
            Clear();
            // Loop for the turns
            int tour = 0;
            while (tour != 30)
            {
                foreach (Player p in game.Player_list)
                {
                    PlayerAction(p,tour);
                    TurnOfPlayer(p);
                    UpdateView(tour);
                    PlayerAction2(p);
                }
                tour++;
            }
        }

        public void TurnOfPlayer(Player player)
        {   
            //if the player is in jail he must try to escape instead of moving
            //The box effect method in Jail detects on its own when it has to do the TryToEscape
            if(game.Board.PlayerInJail(player))
            {
                game.LaunchCaseMethode(player.Position, player, game.Board);
            }
            else
            {
                int value = game.Board.ValueDice(); // A REGARDER
                int newposition = game.NewPosition(player, value);
                game.LaunchCaseMethode(newposition, player, game.Board);
            }
        }

        public void PlayerAction(Player player,int tour)
        {
            view.AskPlayerforAction(player,tour);
        }
        public void PlayerAction2(Player player)
        {
            view.AskPlayerforAction2(player);
        }

        public void Clear()
        {
            view.ClearConsole();
        }
       

    }
}
