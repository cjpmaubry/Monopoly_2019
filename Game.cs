using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Game
    {
        List<Player> list = new List<Player>();
        Board board;
        Dice dice;

        // Constructor

        public Game()
        {
            int choice = 0;
            List<Player> list = new List<Player>();
            Console.WriteLine("MONOPOLY GAME INITIALISATION\n");
            Console.WriteLine("How many player ?");
            while (choice < 5 && choice >= 2)
            {
                Console.WriteLine("The value must be between 2 and 4 ?");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            string name;
            int color;
            for (int i = 1; i <= choice; i++)
            {
                name = Entername(i);
                color = GiveColor(i);
                Player player = new Player(i, name, color, 0, 500);
                list.Add(player);
            }

            Dice dice = new Dice();
            Board board = new Board();
            this.list = list;
            this.board = board;
            this.dice = dice;
        }


        /// <summary>
        /// Allocate color to a player
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GiveColor(int index)
        {
            int color = 0;
            if (index == 1)
                color = 1; // USE RGB COLOR MAYBE LATER !?
            if (index == 2)
                color = 2;
            if (index == 2)
                color = 3;
            if (index == 4)
                color = 4;
            return color;
        }


        /// <summary>
        /// Allow to a player to choose his name 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Entername(int index)
        {
            string name = null;
            while (name == null)
            {
                Console.WriteLine("Enter the name of player " + index);
                name = Console.ReadLine();
            }
            return name;
        }

        public int ValueDice()
        {
            dice.RollDice();
            int value = dice.SumDice();
            return value;
        }

        public int NewPosition(Player player, int value)
        {
            player.Position = (value + player.position) % 40;
            return player.Position;
        }

        public void LaunchCaseMethode(int newposition,Player player)
        {
           Abs_Box box = board.gameboard[newposition];
           box.BoxEffect(player);
        }
    }
}
