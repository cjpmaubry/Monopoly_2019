using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class SingletonDice
    {
        private static SingletonDice instance;
        private static readonly object objlock = new object();

        private SingletonDice() { }

        public static SingletonDice Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (objlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDice();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
