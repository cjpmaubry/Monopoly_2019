using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Luck : Abs_Box
    {

        //Constructor
        public Luck(int position) : base(position)
        {
            this.box_description = "luck";
        }

        public override string BoxEffect(Player joueur, Board monopoly)
        {
            //Give a luck "card" to the player
            string message=monopoly.GiveLuck(joueur);
            return message;
        }




    }
}
