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
            view.UpdateDisplayBoard(game.Board, game.Player_list, tour);
        }

        /// <summary>
        /// This fonction is "the main" fonction because it launch the game
        /// </summary>
        public void LaunchGame()
        {
            Initialisation();

            // Loop for the turns
            int tour = 0;
            while (tour != 20)
            {
                foreach (Player p in game.Player_list)
                {
                    PlayerAction(p);
                    TurnOfPlayer(p);
                    UpdateView(tour);
                    PlayerAction2(p);
                }
                tour++;
            }
        }

        public void TurnOfPlayer(Player player)
        {          
            int value = game.Board.ValueDice(); // A REGARDER
            int newposition=game.NewPosition(player, value);
            game.LaunchCaseMethode(newposition, player,game.Board);
        }

        public void PlayerAction(Player player)
        {
            view.AskPlayerforAction(player);
        }
        public void PlayerAction2(Player player)
        {
            view.AskPlayerforAction2(player);
        }



    }
}
