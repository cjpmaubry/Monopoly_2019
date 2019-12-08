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
        void NotifyProperty(int position, Board board);
    }
}
