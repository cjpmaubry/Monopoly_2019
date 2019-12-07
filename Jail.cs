using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Jail : Abs_Box
    {

        //Constructor
        public Jail(int position) : base(position)
        {
            this.box_description = "jail";
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
            //if the player is in jail
            
            if(monopoly.PlayerInJail(joueur, monopoly))
            {
                int move = 0;
                int tries = 0;
                //The player has three tries at each turn
                while(tries < 3 && move == 0)
                {
                    //TryToEscape will only return the sum of the dices if it is a pair
                    move = TryToEscape(joueur, monopoly);
                    tries++;

                    if(move != 0)
                    {
                        //deletes the player from the jailed_players list
                        monopoly.FreeFromJail(joueur);
                        //makes the player move
                        joueur.Position += move;
                    }
                }
            }
            else
            {
                //Nothing happens, he is a visitor
            }
        }

        /// <summary>
        /// The player tries to escapes
        /// He rolls the dices, if he gets a double he can escape from jail
        /// </summary>
        /// <returns>Returns 0 if he fails, the sum of the dices if he succeeds</returns>
        private int TryToEscape(Player joueur, Board monopoly)
        {
            Console.WriteLine("Press enter to roll the dice and try to escape");
            Console.ReadKey();

            //player rolls the dice
            monopoly.Dices.RollDice();

            //if he makes a double
            if(monopoly.Dices.DoubleDice())
            {
                //returns the sum of the dices to allow him to move
                return monopoly.Dices.SumDice();
            }
            else
            {
                return 0;
            }
        }
    }
}
