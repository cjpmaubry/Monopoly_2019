using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Tax : Abs_Box
    {
        private string name;
        //Constructor
        public Tax(int position, string name1) : base(position)
        {
            this.name = name1;
            this.box_type = "tax";
            this.color = ConsoleColor.DarkGray;
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Give a 200M "tax" to the player
            joueur.LoseMoney(200);

        }

        /// <summary>
        ///  Method ToString to display usefull information of the box ( string display with the help of the view )
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + ": " + name + "\n" +
                "You will pay a 200M tax\n";
        }
    }
}
