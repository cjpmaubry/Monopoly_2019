using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Tax : Abs_Box
    {
        //Constructor
        public Tax(int position) : base(position)
        {
            this.box_type = "tax";
            this.color = ConsoleColor.DarkGray;
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Give a "tax" to the player
            GiveTax(joueur, monopoly);

        }
        public void GiveTax(Player joueur, Board monopoly)
        {           
                Console.WriteLine("Tax : Paid 200 M !");
                joueur.LoseMoney(200);        
        }


        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will paid a tax\n";
        }
    }
}
