using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class GoToJail : Abs_Box
    {
        public GoToJail(int position) : base(position)
        {
            this.box_description = "gotojail";
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //sends the player to jail
            monopoly.SendTojail(joueur);
        }

    }
}
