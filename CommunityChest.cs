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
            this.color = ConsoleColor.DarkBlue; //JEREM 
        }

        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //Give a community chest "card" to the player
            GiveCommunityChest(joueur, monopoly);

        }
        public void GiveCommunityChest(Player joueur, Board monopoly)
        {
            Random alea = new Random();
            int index = alea.Next(1, 5);

            if (index == 1)
            {
                Console.WriteLine("You have luck, you receive 100 euro !");
                joueur.Money += 100;
            }
            if (index == 2)
            {
                Console.WriteLine("You have no luck, you lose 100 euro !");
                joueur.Money -= 100;
            }
            if (index == 3)
            {
                Console.WriteLine("Nothing happens !");
            }
            if (index == 4)
            {
                Console.WriteLine("You have no luck, you go to jail !");
                monopoly.SendTojail(joueur);
            }
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will receive a luck card :\n";
        }

    }
}
