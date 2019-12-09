﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Luck : Abs_Box
    {

        //Constructor
        public Luck(int position) : base(position)
        {
            this.box_type = "luck";
            this.color = ConsoleColor.DarkGray; 
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Give a luck "card" to the player
            GiveLuck(joueur,monopoly);

        }
        public void GiveLuck(Player joueur,Board monopoly)
        {
            Random alea = new Random();
            int index = alea.Next(1, 5);

            if (index == 1)
            {
                Console.WriteLine("Luck Card : Receive 100 M !");
                joueur.Money += 100;   
            }
            if (index == 2)
            {
                Console.WriteLine("Luck Card : Pay 100 M !");
                joueur.Money -= 100;  
            }
            if (index == 3)
            {
                Console.WriteLine("Luck Card : Nothing happens !");
            }
            if (index == 4)
            {
                Console.WriteLine("Luck Card : Go To Jail");
                monopoly.SendTojail(joueur);
            }
            
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will receive a luck card\n";
        }

    }
}
