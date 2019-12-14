using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Proprety : Abs_Box
    {
        private string name;
        private Player owner;
        private int price;
        private int rent;
        private int nmbr_houses;

        public Proprety(int position, string name1, int price1, int rent1, System.ConsoleColor color1) : base(position)
        {
            this.box_type = "proprety";
            this.color = color1; 
            this.name = name1;
            this.owner = null;
            this.price = price1;
            this.rent = rent1;
            this.nmbr_houses = 0;
        }

        /// <summary>
        /// If the proprety is for sale the player can try to buy it.
        /// If it is own the player will pay the rent, except if he is the owner.
        /// </summary>
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //if it is for sale
            if(owner == null)
            {
                string line = Console.In.ReadLine();
                try
                {
                    int offer = int.Parse(line);
                    //the player needs to type the correct price to show that he wants to buy
                    if(offer == price)
                    {
                        TryToBuy(joueur, monopoly);
                    }
                }
                catch(Exception e)
                {
                    Console.Out.WriteLine("You chose to not buy the property (you didn't enter the price)\n");
                }
            }
            //if it belongs to someone
            else
            {
                PayRent(joueur, owner);
            }
        }

        /// <summary>
        /// Method ToString to display usefull information of the box ( string display with the help of the view )
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string description = "\n"+ box_type.ToUpper() + " : " + name;
            if(owner == null)
            {
                description += "\nThe proprety is for sale for " + price + ". Do you want to buy it ?";
                description += "\nIf you dont have enough money the transaction will fail automatically\n" +
                    "\nType in the price shown above if you want to buy it, type 0 if you dont.\n";
            }
            else
            {
                description += "\nBelongs to " + owner.Name + ". \n" +
                    "Rent is " + RentCalculator() + "M\n";
            }
            return description;
        }

        /// <summary>
        /// Calculates the rent value from the rent and the number of houses on the proprety
        /// </summary>
        /// <returns>Return the total rent to pay</returns>
        private int RentCalculator()
        {
            int final_rent = rent;
            for(int i = 0; i < nmbr_houses; i++)
            {
                final_rent = final_rent * 2;
            }
            return final_rent;
        }

        /// <summary>
        /// Tries to make the trasaction.
        /// If the player doesnt have enough money it will fail.
        /// If he has the correct amount, the amount will be taken from his money and the proprety
        /// will be added to his own.
        /// </summary>
        /// <param name="joueur">Player trying to buy</param>
        private void TryToBuy(Player joueur, Board monopoly)
        {
            if(joueur.Money >= price)
            {
                //pays for the proprety
                joueur.LoseMoney(price);
                //owner becomes the player
                owner = joueur;
                //proprety added to personnal list
                joueur.AddProprety(monopoly);
            }
        }

        /// <summary>
        /// If the visitor is not the owner he pays the rent
        /// and the owner gets the rent.
        /// If the visitor is the owner nothing happens.
        /// Also uses the RentCalculator.
        /// </summary>
        /// <param name="visitor">the visiting player</param>
        /// <param name="the_owner">the owner of th eproprety</param>
        private void PayRent(Player visitor, Player the_owner)
        {
            if(visitor.Id != the_owner.Id)
            {
                //visitor loses money
                visitor.LoseMoney(RentCalculator());
                //and the owner gets the money
                the_owner.AddMoney(RentCalculator());
            }
        }
    }
}
