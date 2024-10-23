using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TransactionEventArgs : EventArgs
    {
        public int amount;
        public Account recipient;
        public Account sender;

        public TransactionEventArgs(int amount, Account recipient, Account sender)
        {
            this.amount = amount;
            this.recipient = recipient;
            this.sender = sender;
        }
    }
}
