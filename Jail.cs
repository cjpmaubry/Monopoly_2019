using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Jail : Abs_Box
    {
        public Jail(int position) : base(position)
        {
            this.box_description = "jail";
        }

        public void tryToEscape()
        {

        }
    }
}
