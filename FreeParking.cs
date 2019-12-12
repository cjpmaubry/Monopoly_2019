using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class FreeParking : Abs_Box
    {
        private int free_money;
        public FreeParking(int position) : base(position)
        {
            this.box_type = "free parking";
            this.color = ConsoleColor.Green;
            this.free_money = 0;
        }

        /// <summary>
        /// The player receives the money stored in the FreeParking
        /// If this method is called by the luck or community card, the amount
        /// of money increases because a player got unlucky with his card
        /// and had to pay.
        /// </summary>
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //if the player landed on the box he receives the money
            if(joueur.Position == position)
            {
                joueur.AddMoney(free_money);
                //resets the free money
                free_money = 0;
            }
            //if this method is called by the luck or community card it means that a player
            //had to pay 100 M. This money is stored in this box.
            else
            {
                free_money += 100;
            }
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will receive " + free_money +"M\n";
        }
    }
}
