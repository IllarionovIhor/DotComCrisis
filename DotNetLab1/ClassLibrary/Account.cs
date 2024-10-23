using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Account
    {
        public string Name { get; private set; }
        public string CardNumber { get; private set; }
        public string Pin { get; private set; }
        public int Balance { get; private set; }

        public Account(string name, string cardNumber, string pin, int balance)
        {
            this.Name = name;
            this.CardNumber = cardNumber;
            this.Pin = pin;
            this.Balance = balance;
        }

        public void balanceChange(int amount)
        {
            Balance += amount;
        }
    }
}