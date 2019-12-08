using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class GoToJail : Abs_Box
    {
        public GoToJail(int position) : base(position)
        {
            this.box_type = "gotojail";
            this.color = "Red"; //JEREM
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //sends the player to jail
            monopoly.SendTojail(joueur);
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will now be sent to jail \n";
        }
    }
}
