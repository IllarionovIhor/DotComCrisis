using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class LackBalanceEventArgs : EventArgs
    {
        public int needed;
        public int balance;

        public LackBalanceEventArgs(int needed, int balance)
        {
            this.needed = needed;
            this.balance = balance;
        }
    }
}
    