using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Game
    {
        List<Player> list = new List<Player>();
        Board board;

        // Constructor
        public Game(List<Player> list, Board board)
        {
            this.list = list;
            this.board = board;
        }
    }
}
