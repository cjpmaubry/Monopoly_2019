using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Board
    {
        private Abs_Box[] gameboard;
        private List<Player> jailed_players;
        private Dice dices;

        public Board()
        {
            this.gameboard = new Abs_Box[40];
        }

        //Function wich allocates boxes to the board using the factory pattern
        public void InitialiseBoard()
        {
            BoxFactory.createJail(10, gameboard);
            BoxFactory.createGoToJail(30, gameboard);
            for (int i = 0; i < gameboard.Length; i++)
            {
                //if the box has no role attributed
                if (gameboard[i].box_description == null)
                { 
                    BoxFactory.createNeutral(i, gameboard);
                }
            }
        }
    }
}
