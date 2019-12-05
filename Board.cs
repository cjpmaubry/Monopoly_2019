using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Board
    {
        Abs_Box[] gameboard;

        public Board(Abs_Box[] gameboard)
        {
            this.gameboard = gameboard;
        }
    }

    //Function wich allocates boxes to the board using the factory pattern
    public void AllocateBoard(Abs_Box[] board)
    {
        BoxFactory.createJail(9, board);
        BoxFactory.createGoToJail(29, board);
        for (int i = 0; i < board.Length; i++)
        {
            if (i != 9 || i != 29)
            {
                BoxFactory.createNeutral(i, board);
            }
        }
    }
}
