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

        //creates a Proprety at the given position
        public static void createProprety(int position, Abs_Box[] plateau, string name, int price, int rent, System.ConsoleColor color)
        {
            plateau[position] = new Proprety(position, name, price, rent, color);
        }

        public static void createRailroad(int position, Abs_Box[] plateau, string name)
        {
            plateau[position] = new Railroad(position, name);
        }

        //creates a Luck box at given position
        public static void createLuck(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Luck(position);
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

        //creates a Community chest  box at given position
        public static void createCommunityChest(int position, Abs_Box[] plateau)
        {
            plateau[position] = new CommunityChest(position);
        }

        //creates a Tax box at given position
        public static void createTax(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Tax(position);
        }
    }
}
