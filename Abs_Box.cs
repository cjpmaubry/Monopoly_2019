using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public abstract class Abs_Box
    {
        public int position;
        public string box_type;
        public System.ConsoleColor color;

        public Abs_Box(int position)
        {
            this.position = position;
        }

        /// <summary>
        /// Takes a player and apllies the effect of the box
        /// The default method called by the controller when a player arrives on a box
        /// </summary>
        /// <param name="joueur">Affected player</param>
        /// <param name="gameboard">Board of the game, contains all the boxs</param>
        public abstract void BoxEffect(Player joueur, Board monopoly);

        /// <summary>
        /// Describes the box by its type and more information if needed
        /// </summary>
        /// <returns>String that will be used in the view</returns>
        public abstract string ToString(Board monopoly);
    }
}
