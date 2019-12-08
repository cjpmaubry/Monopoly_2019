using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    public class Player : ISubject
    {
        private int id;
        private string name;
        private int color;
        private int position;
        private double money;
        private ObservePlayer observer;

        // Constructor
        public Player(int id, string name, int color, int position, double money)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.position = position;
            this.money = money;
        }

        /// <summary>
        /// Getter and Setter for Position
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                NotifyPosition();
            }
        }
        /// <summary>
        /// Getter and Setter for Money
        /// </summary>
        public double Money
        {
            get
            {
                return this.money;
            }
            set
            {
                this.money = value;
                NotifyMoney();
            }
        }

        public int Id 
        { 
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Getter for name of the player
        /// </summary>
        public string Name { get => name; }

        /// <summary>
        /// Allow the posibility to attach an observer
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(ObservePlayer observer)
        {
            this.observer = observer;
        }

        /// <summary>
        /// Allow the posibility to detach an observer
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(ObservePlayer observer)
        {
            this.observer = observer;
        }

        /// <summary>
        /// Notify the position of a player on the board
        /// </summary>
        private void NotifyPosition()
        {
            observer.UpdatePosition(this.position, this.name);
        }

        /// <summary>
        ///  Notify the money of a player 
        /// </summary>
        private void NotifyMoney()
        {
            observer.UpdateMoney(this.money, this.name);
        }

        /// <summary>
        /// Adds money to the palyers money
        /// </summary>
        /// <param name="gain">Amount of money to add</param>
        public void AddMoney(int gain)
        {
            Money += Math.Abs(gain);
        }

        /// <summary>
        /// Removes money from the players money
        /// </summary>
        /// <param name="loss">Amount of money to remove</param>
        public void LoseMoney(int loss)
        {
            Money += Math.Abs(loss);
        }
    }
}
