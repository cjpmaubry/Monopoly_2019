using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class BoxFactory
    {
        //creates a Go box at the given position
        public static void createGo(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Go(position);
        }

        //creates a Jail box at the given position
        public static void createJail(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Jail(position);
        }

        //creates a GoToJail box at the given position
        public static void createGoToJail(int position, Abs_Box[] plateau)
        {
            plateau[position] = new GoToJail(position);
        }

        //created a Neutral box at the given position
        public static void createNeutral(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Neutral(position);
        }

        //created a Neutral box at the given position
        public static void createLuck(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Luck(position);
        }

    }
}
