using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class BoxFactory
    {
        /// <summary>
        /// Creates a Go box at the given position
        /// </summary>
        public static void createGo(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Go(position);
        }

        /// <summary>
        /// Creates a Proprety at the given position
        /// </summary>
        public static void createProprety(int position, Abs_Box[] plateau, string name, int price, int rent, System.ConsoleColor color)
        {
            plateau[position] = new Proprety(position, name, price, rent, color);
        }

        /// <summary>
        /// Creates a Utility at the given position
        /// </summary>
        public static void createUtility(int position, Abs_Box[] plateau, string name)
        {
            plateau[position] = new Utility(position, name);
        }

        /// <summary>
        /// Creates a Railroad at the given position
        /// </summary>
        public static void createRailroad(int position, Abs_Box[] plateau, string name)
        {
            plateau[position] = new Railroad(position, name);
        }

        /// <summary>
        /// Creates a Luck box at given position
        /// </summary>
        public static void createLuck(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Luck(position);
        }

        /// <summary>
        /// Creates a Free Parking box at the given position
        /// </summary>
        public static void createFreeParking(int position, Abs_Box[] plateau)
        {
            plateau[position] = new FreeParking(position);
        }

        /// <summary>
        /// Creates a Jail box at the given position
        /// </summary>
        public static void createJail(int position, Abs_Box[] plateau)
        {
            plateau[position] = new Jail(position);
        }

        /// <summary>
        /// Creates a GoToJail box at the given position
        /// </summary>
        public static void createGoToJail(int position, Abs_Box[] plateau)
        {
            plateau[position] = new GoToJail(position);
        }

        /// <summary>
        /// Creates a Community Chest box at given position
        /// </summary>
        public static void createCommunityChest(int position, Abs_Box[] plateau)
        {
            plateau[position] = new CommunityChest(position);
        }

        /// <summary>
        /// Creates a Tax box at given position
        /// </summary>
        public static void createTax(int position, Abs_Box[] plateau, string name)
        {
            plateau[position] = new Tax(position, name);
        }
    }
}
