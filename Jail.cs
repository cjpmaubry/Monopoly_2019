using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Jail : Abs_Box
    {
        //used to keep track of the number of turns in jail spent by the players
        private int[] turns_in_jail;

        //Constructor
        public Jail(int position) : base(position)
        {
            this.box_type = "jail";
            this.color = ConsoleColor.Red;
            this.turns_in_jail = new int[4] { 0, 0, 0, 0 }; //4 is the maximum number of players
        }

        /// <summary>
        /// Checks if the player is in jail or just a visitor
        /// If he is in jail he gets 3 tries to get out
        /// If he gets out he will move
        /// If he is just a visitor, nothing happens
        /// </summary>
        /// <param name="joueur">The playing player</param>
        /// <param name="monopoly">The monopoly game set</param>
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            int prisonner_number = monopoly.PlayerInJail(joueur);
            //The prisonner number is used to keep track of the number of turns he psends in prison
            //if he isnt in jail the number 4 will be returned by PlayerinJail

            //if the player is in jail
            if(monopoly.PlayerInJail(joueur) < 4)
            {
                Console.WriteLine("YOU ARE IN PRISON");
                int move = 0;

                //The player can try to escape one time at each turn for three turns
                if(turns_in_jail[prisonner_number] < 3)
                {
                    //TryToEscape will only return the sum of the dices if it is a pair
                    Console.WriteLine("Turn " + (turns_in_jail[prisonner_number] + 1) + " in jail :");
                    move = TryToEscape(joueur, monopoly);
                    //adds a turn passed in jail
                    turns_in_jail[prisonner_number]++;

                    if (move != 0)
                    {

                        Console.WriteLine("You got out of jail ! Press any key to continue");
                        Console.ReadKey();
                        //deletes the player from the jailed_players list
                        monopoly.FreeFromJail(joueur);
                        //resets the turns passed in prison to zero
                        turns_in_jail[prisonner_number] = 0;
                        //makes the player move
                        joueur.Position += move;
                    }
                                    
                }
                //if still he didnt escape in three turn, he pays a fine and gets out
                if(turns_in_jail[prisonner_number] == 3 && monopoly.PlayerInJail(joueur) < 4)
                {
                    Console.WriteLine("You spent 3 turns in prison\n" +
                        "You paid 50 M to get out\n");
                    //pays the 50 M fine
                    joueur.LoseMoney(50);
                    //gets freed from jail
                    monopoly.FreeFromJail(joueur);
                    //resets the turns passed in prison to zero
                    turns_in_jail[prisonner_number] = 0;
                }
             }
            else
            {
                //Nothing happens, he is a visitor
                Console.WriteLine("Just visiting prison");
            }
        }

        /// <summary>
        /// The player tries to escapes
        /// He rolls the dices, if he gets a double he can escape from jail
        /// </summary>
        /// <returns>Returns 0 if he fails, returns the sum of the dices if he succeeds</returns>
        private int TryToEscape(Player joueur, Board monopoly)
        {
            Console.WriteLine("Press any key to roll the dice and try to make a double");
            Console.ReadKey();

            //if he makes a double
            if(monopoly.Dices.RollDice())
            {
                //returns the sum of the dices to allow him to move
                return monopoly.Dices.SumDice();
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\n";
        }
    }
}
