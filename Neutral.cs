using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Neutral : Abs_Box
    {
        public Neutral(int position) : base(position)
        {
            this.box_description = "neutral";
        }
    }
}
