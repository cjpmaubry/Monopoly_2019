using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Board
    {
        Abs_Box[] gameboard;
        private List<Player> jailed_players;
        private Dice dices;

        public Board()
        {
            this.gameboard = new Abs_Box[40];
            this.jailed_players = new List<Player>();
            this.dices = new Dice();
        }

        //Getters
        public List<Player> Jailed_players { get => jailed_players;}
        internal Dice Dices { get => dices;}

        /// <summary>
        /// Initialises the game by filling the boxs of the board with a defined role
        /// </summary>
        public void InitialiseBoard()
        {
            BoxFactory.createJail(10, gameboard);
            BoxFactory.createGoToJail(30, gameboard);
            for (int i = 0; i < gameboard.Length; i++)
            {
                if (i != 9 || i != 29)
                {
                    BoxFactory.createNeutral(i, gameboard);
                }
            }
        }

        /// <summary>
        /// Sends a player to jail
        /// Adds it to the list of trapped players
        /// Changes its position to the position of the jail
        /// </summary>
        /// <param name="joueur">Player sent to jail</param>
        public void SendTojail(Player joueur)
        {
            //adds the player to the list of trapped players
            jailed_players.Add(joueur);

            //sets the position of the player to the position of the jail, 10
            joueur.Position = 10;
        }

        /// <summary>
        /// Checks that a player is in jail and then removes him from it
        /// </summary>
        /// <param name="joueur">Player to free</param>
        public void FreeFromJail(Player joueur)
        {
            foreach(Player prisonner in jailed_players)
            {
                //we check that the player is indeed in jail
                if(prisonner.Name == joueur.Name)
                {
                    jailed_players.Remove(joueur);
                }
            }
        }
    }
}
