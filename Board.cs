using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Monopoly_2019
{
    public class Board
    {
        private Abs_Box[] gameboard;
        private List<Player> jailed_players;
        private SingletonDice dices;
        private static readonly object objlock = new object();
        private static Board instance;

        public Board()
        {
            this.gameboard = new Abs_Box[40];
            this.jailed_players = new List<Player>();
            this.dices = SingletonDice.GetInstance();
            ObserveDice observer = new ObserveDice("1");
            dices.Attach(observer);
        }

        //Getters
        public List<Player> Jailed_players { get => jailed_players; }
        //internal Dice Dices { get => dices;}
        public Abs_Box[] Gameboard { get => gameboard; }
        internal SingletonDice Dices { get => dices; }

        public static Board getInstance()
        {
            if (instance == null)
            {
                lock (objlock)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Initialises the game by filling the boxs of the board with a defined role
        /// </summary>
        public void InitialiseBoard()
        {
            InitialisePropreties();

            BoxFactory.createGo(0, gameboard);

            BoxFactory.createLuck(7, gameboard);
            BoxFactory.createLuck(22, gameboard);
            BoxFactory.createLuck(36, gameboard);

            BoxFactory.createCommunityChest(2, gameboard);
            BoxFactory.createCommunityChest(17, gameboard);
            BoxFactory.createCommunityChest(33, gameboard);

            BoxFactory.createJail(10, gameboard);
            BoxFactory.createGoToJail(30, gameboard);
            for (int i = 0; i < gameboard.Length; i++)
            {
                //if the box has no role attributed
                if (gameboard[i] == null)
                {
                    BoxFactory.createNeutral(i, gameboard);
                }
            }
        }

        /// <summary>
        /// Uses a csv file to create all the offical propreties in the game
        /// 1 : Finds the executable directory of the project on the users computer
        /// 2 : Puts the propreties.csv file in it in order to use it as a ressource
        /// 3 : Adds each propreties contained in the file to the board of the game
        /// </summary>
        private void InitialisePropreties()
        {
            //Finds the executable location of the project on the computer
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] exe_location = executableLocation.Split("\\");

            //Finds and creates a variable containing the path to the properties.csv file
            string propreties_location = null;
            int index = 0;
            while (exe_location[index] != "bin")
            {
                propreties_location += exe_location[index];
                propreties_location += "\\";
                index++;
            }
            propreties_location += "propreties.csv";

            //copies the propreties file to the executable directory
            string sourceFile = propreties_location;
            string destinationFile = Path.Combine(executableLocation, "propreties.csv"); ;
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }

            //extracts the information contained in the csv file
            System.IO.StreamReader propreties_file = new System.IO.StreamReader("propreties.csv");

            string line;
            while ((line = propreties_file.ReadLine()) != null)
            {
                string[] list_description = line.Split(';');

                //creates proprety instances in the board of the game
                int p_position = int.Parse(list_description[0]);
                string p_name = list_description[1];
                int p_price = int.Parse(list_description[2]);
                int p_rent = int.Parse(list_description[3]);
                System.ConsoleColor p_color = (System.ConsoleColor)int.Parse(list_description[4]);

                BoxFactory.createProprety(p_position, gameboard, p_name, p_price, p_rent, p_color);
            }
        }

        /// <summary>
        /// Checks if the player is part of the jailed_players list
        /// </summary>
        /// <returns>Return true if he is in jail</returns>
        public bool PlayerInJail(Player joueur)
        {
            foreach (Player prisonner in jailed_players)
            {
                //looks at the names to see if the player is in jail
                if (joueur.Name == prisonner.Name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sends a player to jail
        /// Adds it to the list of trapped players
        /// Changes its position to the position of the jail
        /// </summary>
        /// <param name="joueur">Player sent to jail</param>
        public void SendTojail(Player joueur)
        {
            //adds the player to the list of trapped players
            jailed_players.Add(joueur);

            //sets the position of the player to the position of the jail, 10
            joueur.Position = 10;
        }

        /// <summary>
        /// Checks that a player is in jail and then removes him from it
        /// </summary>
        /// <param name="joueur">Player to free</param>
        public void FreeFromJail(Player joueur)
        {
            if (PlayerInJail(joueur))
            {
                jailed_players.Remove(joueur);
            }
        }





        public int ValueDice()
        {
            int value = dices.SumDice();
            return value;
        }

        public bool Roll()
        {
            bool made_a_double = dices.RollDice();
            return made_a_double;
        }
    }
}
