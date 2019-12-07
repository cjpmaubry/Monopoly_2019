using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    interface ISubjectDice
    {
        void Attach(ObserveDice observer);
        void Detach(ObserveDice observer);
        void NotifyDice(int[] dices);
        void NotifyDoubleDice();
    }
}
