using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    class SingletonBoard
    {
        private static SingletonBoard instance;
        private static readonly object objlock = new object();

        private SingletonBoard() { }

        public static SingletonBoard getInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (objlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonBoard();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
