using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Neutral : Abs_Box
    {
        public Neutral(int position) : base(position)
        {
            this.box_type = "neutral";
            this.color = "Black"; //JEREM
        }

        //Nothing happens on neutral boxes
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Nothing happens on neutral boxes
        }

        public override string ToString()
        {
            return "You have landed on " + box_type.ToUpper() + "\n Nothing will happen";
        }
    }
}
