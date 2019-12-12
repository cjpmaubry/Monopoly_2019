using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Game
    {
        List<Player> player_list = new List<Player>();
        Board board;

        // Constructor
        public Game()
        {
            List<Player> tempPlayers = new List<Player>();
            Console.WriteLine("MONOPOLY GAME INITIALISATION\n");
            Console.WriteLine("How many players ?");
            int choice = 0;
            string line = Console.In.ReadLine();
            try
            {
                choice = int.Parse(line);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("L'erreur suivante s'est produite : " + e.Message);
            }
            while (choice >= 5 || choice < 2)
            {
                Console.WriteLine("Choose between 2 and 4 players");
                line = Console.In.ReadLine();
                try
                {
                    choice = int.Parse(line);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("L'erreur suivante s'est produite : " + e.Message);
                }
            }
            //Player information
            string name;
            int color;
            for (int i = 1; i <= choice; i++)
            {
                name = Entername(i);
                color = GiveColor(i);
                Player player = new Player(i, name, color, 0, 500);
                ObservePlayer observer = new ObservePlayer(Convert.ToString(i));
                player.Attach(observer);
                tempPlayers.Add(player);
            }

            //Initialisation of the board
            this.board = Board.getInstance();
            this.board.InitialiseBoard();
            this.player_list = tempPlayers;
        }

        //Getters
        public Board Board { get => board; }

        public List<Player> Player_list { get => player_list; }


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
            while (name == null || name=="")
            {
                Console.WriteLine("Enter the name of player " + index);
                name = Console.ReadLine();
            }
            return name;
        }


        /// <summary>
        /// Method that move player to the new position and add money if end a full tour
        /// </summary>
        /// <param name="player"></param>
        /// <param name="value"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public int NewPosition(Player player, int value,Board board)
        {
            int temporal = player.Position;
            player.Position = (value + player.Position) % 40;
            if(player.Position<temporal)
            {
                board.Gameboard[0].BoxEffect(player, board);
            }
            return player.Position;
        }

        /// <summary>
        /// This method execute the box effect for the player in this box
        /// </summary>
        /// <param name="newposition"></param>
        /// <param name="player"></param>
        /// <param name="board"></param>
        public void LaunchCaseMethode(int newposition,Player player,Board board)
        {
            board.Gameboard[newposition].BoxEffect(player,board);
            
        }
    }
}
