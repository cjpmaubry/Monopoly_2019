using System;
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
            string message = "";
            Random alea = new Random();
            int index = alea.Next(1, 5);

            if (index == 1)
            {
                joueur.Money += 100;
                message = "You have luck, you receive 100 euro !";
            }
            if (index == 2)
            {
                joueur.Money -= 100;
                message = "You have no luck, you lose 100 euro !";
            }
            if (index == 3)
            {
                message = "Nothing happens !";
            }
            if (index == 4)
            {
                message = "You have no luck, you go to jail !";
                monopoly.SendTojail(joueur);
            }
            Console.WriteLine(message);
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will receive a luck card :\n";
        }

    }
}
