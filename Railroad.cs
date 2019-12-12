using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Railroad : Abs_Box
    {
        private string name;
        private Player owner;
        private int price;
        private int rent;

        public Railroad(int position,string name1) : base(position)
        {
            this.box_type = "railroad";
            this.color = ConsoleColor.White;
            this.price = 200; //each railroad is worth 200 M
            this.rent = 25;
            this.owner = null;
            this.name = name1;
        }

        /// <summary>
        /// If the railroad is for sale the player can try to buy it.
        /// If it is own the player will pay the rent, except if he is the owner.
        /// </summary>
        public override void BoxEffect(Player joueur, Board monopoly)
        {
            //if it is for sale
            if (owner == null)
            {
                string line = Console.In.ReadLine();
                try
                {
                    int offer = int.Parse(line);
                    //the player needs to type the correct price to show that he wants to buy
                    if (offer == price)
                    {
                        TryToBuy(joueur, monopoly);
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("The following error has occured : " + e.Message);
                }
            }
            //if it belongs to someone
            else
            {
                PayRent(joueur, owner);
            }
        }

        public override string ToString()
        {
            string description = "\n" + box_type.ToUpper() + " : " + name;
            if (owner == null)
            {
                description += "\nThe railroad is for sale for " + price + ". Do you want to buy it ?";
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
        /// Calculates the rent value from the number of railroads owed by the owner
        /// </summary>
        /// <returns>Return the total rent to pay</returns>
        private int RentCalculator()
        {
            int railroads_owned = 0;
            if(owner != null)
            {
                foreach (Abs_Box proprety in owner.Propreties)
                {
                    if (proprety.box_type == "railroad")
                    {
                        //the final rent will double for each railroad owned by the owner
                        railroads_owned ++;
                    }
                }
            }
            else 
            { 
                //if no owner then return the default value
                return rent; 
            }
            //the final rent doubles for each railroad owned by the owner
            return rent * (int)Math.Pow(2,railroads_owned-1);
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
            if (joueur.Money >= price)
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
        /// <param name="the_owner">the owner of the railroad</param>
        private void PayRent(Player visitor, Player the_owner)
        {
            if (visitor.Id != the_owner.Id)
            {
                //visitor loses money
                visitor.LoseMoney(RentCalculator());
                //and the owner gets the money
                the_owner.AddMoney(RentCalculator());
            }
        }
    }
}
