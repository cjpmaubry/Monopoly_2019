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
        public void NotifyPosition()
        {
            observer.UpdatePosition(this.position, this.name);
        }

        /// <summary>
        ///  Notify the money of a player 
        /// </summary>
        public void NotifyMoney()
        {
            observer.UpdateMoney(this.money, this.name);
        }
    }
}
