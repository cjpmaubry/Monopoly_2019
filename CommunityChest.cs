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
            this.color = ConsoleColor.DarkMagenta;
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
                Console.WriteLine("Community Chest : Receive 100 M !");
                joueur.AddMoney(100);
            }
            if (index == 2)
            {
                Console.WriteLine("Community Chest : Pay 100 M !");
                joueur.LoseMoney(100);
            }
            if (index == 3)
            {
                Console.WriteLine("Community Chest : Nothing happens !");
            }
            if (index == 4)
            {
                Console.WriteLine("Community Chest : Go on the Go Case");
                joueur.Position = 0;
            }
        }

        public override string ToString()
        {
            return "\nYou have landed on " + box_type.ToUpper() + "\nYou will receive a community chest card\n";
        }

    }
}
