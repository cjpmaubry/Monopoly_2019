using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly_2019
{
    interface ISubject
    {
        void Attach(ObservePlayer observer);
        void Detach(ObservePlayer observer);
        void NotifyMoney();
        void NotifyPosition();
        void NotifyProperty(List<Abs_Box> propreties, Board board);
    }
}
