using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public abstract class Abs_Box
    {
        public int position;
        public string box_description;

        public Abs_Box(int position)
        {
            this.position = position;
        }

        /// <summary>
        /// Takes a player and apllies the effect of the box
        /// The default method called by the controller when a player arrives on a box
        /// </summary>
        /// <param name="joueur">Player affected</param>
        public void BoxEffect(Player joueur)
        {

        }
    }
}
