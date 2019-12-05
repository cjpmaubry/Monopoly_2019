using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Board
    {
        Abs_Box[] gameboard;

        public Board()
        {
            this.gameboard = new Abs_Box[40];
        }

        //Function wich allocates boxes to the board using the factory pattern
        public void InitialiseBoard()
        {
            BoxFactory.createJail(9, gameboard);
            BoxFactory.createGoToJail(29, gameboard);
            for (int i = 0; i < gameboard.Length; i++)
            {
                if (i != 9 || i != 29)
                {
                    BoxFactory.createNeutral(i, gameboard);
                }
            }
        }
    }
}
