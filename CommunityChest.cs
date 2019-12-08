using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class CommunityChest : Abs_Box
    {
        //Constructor
        public CommunityChest(int position) : base(position)
        {
            this.box_type = "community chest";
            this.color = "Grey"; 
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Give a community chest "card" to the player
            GiveCommunityChest(joueur, monopoly);

        }
        public void GiveCommunityChest(Player joueur, Board monopoly)
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
