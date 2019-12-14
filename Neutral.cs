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
            this.color = ConsoleColor.White;
        }

        //Nothing happens on neutral boxes
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Nothing happens on neutral boxes
        }

        /// <summary>
        ///  Method ToString to display usefull information of the box ( string display with the help of the view )
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nNothing will happen\n";
        }
    }
}
