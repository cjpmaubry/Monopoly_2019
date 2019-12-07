using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    interface IObserverDice
    {
        public void UpdateDiceInfo(int[] dices);
        public void UpdateDoubleDiceInfo();

    }
}
