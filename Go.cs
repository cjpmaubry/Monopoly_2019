using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Go : Abs_Box
    {
        private int go_bonus;
        public Go(int position): base(position)
        {
            this.box_type = "go";
            this.color = ConsoleColor.Green;
            this.go_bonus = 200;
        }

        //The player gets 200M
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            joueur.AddMoney(go_bonus);
        }

        /// <summary>
        ///  Method ToString to display usefull information of the box ( string display with the help of the view )
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nYou have landed exactly on " + box_type.ToUpper() + "\nYou will receive 400M\n";
        }
    }
}
