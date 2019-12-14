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
        private Player[] jailed_players;
        private SingletonDice dices;
        private static readonly object objlock = new object();
        private static Board instance;
        private List<Player> removed_players=new List<Player>();

        private Board()
        {
            this.gameboard = new Abs_Box[40];
            this.jailed_players = new Player[4];
            this.dices = SingletonDice.GetInstance();
            ObserveDice observer = new ObserveDice("1");
            dices.Attach(observer);
        }

        //Getters
        public Player[] Jailed_players { get => jailed_players; }
        public List<Player> Removed_players { get => removed_players; set => removed_players=value;}



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
            BoxFactory.createGo(0, gameboard);
            BoxFactory.createFreeParking(20, gameboard);

            InitialisePropreties();

            BoxFactory.createRailroad(5, gameboard, "Reading Railroad");
            BoxFactory.createRailroad(15, gameboard, "Pennsylvania Railroad");
            BoxFactory.createRailroad(25, gameboard, "B & O Railroad");
            BoxFactory.createRailroad(35, gameboard, "Short Line");

            BoxFactory.createUtility(12, gameboard, "Electric Company");
            BoxFactory.createUtility(28, gameboard, "Water Works");

            BoxFactory.createTax(4, gameboard, "Income Tax");
            BoxFactory.createTax(38, gameboard, "Luxury Tax");

            BoxFactory.createLuck(7, gameboard);
            BoxFactory.createLuck(22, gameboard);
            BoxFactory.createLuck(36, gameboard);

            BoxFactory.createCommunityChest(2, gameboard);
            BoxFactory.createCommunityChest(17, gameboard);
            BoxFactory.createCommunityChest(33, gameboard);

            BoxFactory.createJail(10, gameboard);
            BoxFactory.createGoToJail(30, gameboard);
            //checks if the board is compleet
            for (int i = 0; i < gameboard.Length; i++)
            {
                //if the box has no role attributed
                if (gameboard[i] == null)
                {
                    Console.WriteLine("Missing box at " + i);
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
        /// Returns his prisonner number, or 4 if he isnt in jail
        /// The prisonner number is usde to keep track of the number of turns he psends in prison
        /// </summary>
        /// <returns>Returns his prisonner number (if he was the first to go in jail than he is number 0)</returns>
        public int PlayerInJail(Player joueur)
        {
            int prisonner_number = 0;
            foreach (Player prisonner in jailed_players)
            {
                if(prisonner != null)
                {
                    if (joueur.Name == prisonner.Name)
                    {
                        return prisonner_number;
                    }
                    else
                    {
                        prisonner_number++;
                    }
                }
                else
                {
                    prisonner_number ++;
                }
            }
            //there can only be up to 4 players. So 3 is the max prisonner number
            //reutrning 4 allows us to signal that that player isnt in jail
            return 4;
        }

        /// <summary>
        /// Sends a player to jail
        /// Adds it to the list of trapped players
        /// Changes its position to the position of the jail
        /// </summary>
        /// <param name="joueur">Player sent to jail</param>
        public void SendTojail(Player joueur)
        {
            int prisonner_number = 0;
            //finds the first available spot
            while(jailed_players[prisonner_number] != null)
            {
                prisonner_number++;
            }
            jailed_players[prisonner_number] = joueur;

            //sets the position of the player to the position of the jail, 10
            joueur.Position = 10;
        }

        /// <summary>
        /// Checks that a player is in jail and then removes him from it
        /// </summary>
        /// <param name="joueur">Player to free</param>
        public void FreeFromJail(Player joueur)
        {
            if (PlayerInJail(joueur) < 4)
            {
                //remove the player from his "cell"
                jailed_players[PlayerInJail(joueur)] = null;
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
