using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RegistrationEventArgs : EventArgs
    {
        public string Name { get; }
        public string CardNumber { get; }
        public string Pin { get; }

        public RegistrationEventArgs(string name, string cardNumber, string pin)
        {
            Name = name;
            CardNumber = cardNumber;
            Pin = pin;
        }
    }
}
