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
        public Controller(Game game, View view)
        {
            this.game = game;
            this.view = view;
        }

        /// <summary>
        /// This fonction launch the view update. It allows to vizualize the change of the party
        /// </summary>
        public void ViewUpdate()
        {
            view.Display(this.game);
        }

        /// <summary>
        /// This fonction initialize the game ( with value of the beginning of the game  party )
        /// </summary>
        public void Initialisation()
        {
            // Initialisation des joueurs du plateau et plus générallement du game....
        }


        /// <summary>
        /// This fonction is "the main" fonction because it launch the game
        /// </summary>
        public void LaunchGame()
        {
            this.Initialisation();  // this. ???
            // Boucle pour les tours
            int tour = 0;
            while (tour != 20)
            {
                foreach (Player p in this.game.list) // Il faut creer un pattern Iterator pour pouvoir appliquer le foreach
                {
                    TurnOfPlayer(p);
                }
                tour++;
            }
        }

        public void TurnOfPlayer(Player player)
        {
            int value = ValueDice(); // A DEFINIR
            player.Position = NewPosition(player.position, value);// A DEFINIR

        }




    }
}
