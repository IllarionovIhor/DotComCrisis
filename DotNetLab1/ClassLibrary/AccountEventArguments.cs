using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class AccountEventArguments : EventArgs
    {
        public string name;
        public string cardNumber;
        public string pin;
        public int balance;

        public AccountEventArguments(string name, string cardNumber, string pin, int balance)
        {
            this.name = name;
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.balance = balance;
        }
    }
}
