﻿using System;
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
            this.color = "Blue";
            this.go_bonus = 200;
        }

        //The player gets 200M
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            joueur.AddMoney(go_bonus);
        }

        public override string ToString()
        {
            return "You have landed on " + box_type.ToUpper() + "\n You will receive 200M";
        }
    }
}