using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class Utility : Abs_Box
    {
        private string name;
        private Player owner;
        private int price;

        public Utility(int position, string name) : base(position)
        {
            this.name = name;
            this.owner = null;
            this.price = 150; //each utility is 150M
            this.color = ConsoleColor.White;
            this.box_type = "utility";
        }

        /// <summary>
        /// If the utility is for sale the player can try to buy it.
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
                PayRent(joueur, owner, monopoly);
            }
        }

        /// <summary>
        ///  Method ToString to display usefull information of the box ( string display with the help of the view )
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string description = "\n" + box_type.ToUpper() + " : " + name;
            if (owner == null)
            {
                description += "\nThe utility is for sale for " + price + ". Do you want to buy it ?";
                description += "\nIf you dont have enough money the transaction will fail automatically\n" +
                    "\nType in the price shown above if you want to buy it, type 0 if you dont.\n";
            }
            else
            {
                description += "\nBelongs to " + owner.Name + ". \n" +
                    "The rent is calculated in function of the dices and the number of utilities owned\n";
            }
            return description;
        }

        /// <summary>
        /// Calculates the rent value from the number of utilities owned and the value of the dices
        /// If one utilitie is owned then the rent is 4*the dices
        /// If the owner has both of the utilities than the rent is 10*the dices
        /// </summary>
        /// <param name="monopoly">We need the board in order to acces the dices</param>
        /// <returns>Return the total rent to pay</returns>
        private int RentCalculator(Board monopoly)
        {
            int nbr_utilities = 0;
            int rent = 0;
            if(owner != null)
            {
                foreach(Abs_Box proprety in owner.Propreties)
                {
                    if (proprety.box_type == "utility")
                    {
                        nbr_utilities ++;
                    }
                }
            }
            if (nbr_utilities == 1)
            {
                //if it is the only proprety owned, then the rent is 4 * the value of the dices
                rent = 4 * monopoly.ValueDice();
            }
            if (nbr_utilities == 2)
            {
                //if the owner has 2 utilities, then the rent is 10 * the value of the dices
                rent = 10 * monopoly.ValueDice();
            }
            return rent;
        }

        /// <summary>
        /// Tries to make the transaction.
        /// If the player doesnt have enough money it will fail.
        /// If he has the correct amount, the amount will be taken from his money and the utility
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
        /// <param name="monopoly">We need the board in order to acces the dices</param>
        /// <param name="visitor">the visiting player</param>
        /// <param name="the_owner">the owner of the railroad</param>
        private void PayRent(Player visitor, Player the_owner, Board monopoly)
        {
            if (visitor.Id != the_owner.Id)
            {
                //visitor loses money
                visitor.LoseMoney(RentCalculator(monopoly));
                //and the owner gets the money
                the_owner.AddMoney(RentCalculator(monopoly));
            }
        }
    }
}
