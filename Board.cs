using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Board
    {
        public Abs_Box[] gameboard;

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
                if (i != 10 && i != 30)
                {
                    BoxFactory.createNeutral(i, gameboard);
                }
            }
        }
    }
}
