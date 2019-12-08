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
            this.color = "Red"; //JEREM
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Give a luck "card" to the player
            GiveLuck(joueur);

        }
        public void GiveLuck(Player joueur)
        {
            string message = "";
            Random alea = new Random();
            int index = alea.Next(1, 4);

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
            Console.WriteLine(message);
        }

        public override string ToString()
        {
            return "You have landed on " + box_type.ToUpper() + "\nYou will receive a luck card :";
        }

    }
}
