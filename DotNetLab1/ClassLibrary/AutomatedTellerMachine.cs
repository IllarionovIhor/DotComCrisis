using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class AutomatedTellerMachine
    {
        public string ID { get; private set; }
        public int Balance { get; private set; }
        public List<Account> DB { get; private set; }
        public Account Acc { get; private set; }
        public string StoragePath { get; private set; }
        public event EventHandler<RegistrationEventArgs> RegistrationSuccess;
        public event EventHandler<RegistrationEventArgs> RegistrationFail;
        public AutomatedTellerMachine(string id, int balance, string savePath)
        {
            ID = id;
            Balance = balance;
            StoragePath = savePath;
            loadFile(savePath);
        }

        public event EventHandler<AccountEventArguments> LogInSuccess;
        public event EventHandler<EventArgs> LogInFail;
        public void AddAccount(string name, string cardNumber, string pin)
        {
            Account newAccount = new Account(name, cardNumber, pin, 0);
            DB.Add(newAccount);
            RegistrationSuccess?.Invoke(this, new RegistrationEventArgs(name, cardNumber, pin));
        }
        public void Register(string name, string cardNumber, string pin)
        {
            AddAccount(name, cardNumber, pin);
            RegistrationSuccess?.Invoke(this, new RegistrationEventArgs(name, cardNumber, pin));
        }
        public bool login(string card,string pin)
        {
            foreach (Account acc in DB)
            {
                if (acc.CardNumber == card && acc.Pin == pin)
                {
                    Acc = acc;
                    LogInSuccess(this,new AccountEventArguments(acc.Name,acc.CardNumber, acc.Pin,acc.Balance));
                    return true;
                }
            }
            LogInFail(this,new EventArgs());
            return false;
        }

        public event EventHandler<EventArgs> LogOut;
        public void logout()
        {
            storageChanges();
            Acc = null;
            LogOut(this,new EventArgs());
        }

        public event EventHandler<EventArgs> NotLoggedIn;
        public bool loggedIn()
        {
            if(Acc == null) { NotLoggedIn(this, new EventArgs()); }
            return Acc != null;
        }

        public event EventHandler<TransactionEventArgs> AmountLessOrEqualsToZero;
        public bool isMoreThanZero(int amount)
        {
            if(amount <= 0) { AmountLessOrEqualsToZero(this, new TransactionEventArgs(amount,null,null)); }
            return amount > 0;
        }

        public event EventHandler<AccountEventArguments> GotBalance;
        public int getAccBalance()
        {
            if (loggedIn()) 
            { 
                GotBalance(this,new AccountEventArguments(Acc.Name,Acc.CardNumber, Acc.Pin,Acc.Balance));
                return Acc.Balance; 
            }
            return -1;
        }

        public event EventHandler<TransactionEventArgs> Added;
        public void put(int amount)
        {
            if (loggedIn() && isMoreThanZero(amount))
            {
                Acc.balanceChange(amount);
                Balance += amount;
                storageChanges();
                Added(this, new TransactionEventArgs(amount, Acc, Acc));
            }
        }


        public event EventHandler<TransactionEventArgs> Withdrawn;
        public event EventHandler<LackBalanceEventArgs> AtmInsufficientBalance;
        public event EventHandler<LackBalanceEventArgs> AccountInsufficientBalance;
        public void withdraw(int amount)
        {
            if (Balance >= amount)
            {
                if (Acc.Balance >= amount)
                {
                    if (loggedIn() && isMoreThanZero(amount))
                    {
                        Acc.balanceChange(-amount);
                        Balance -= amount;
                        storageChanges();
                        Withdrawn(this, new TransactionEventArgs(amount, Acc, Acc));
                    }
                }
                else
                {
                    AccountInsufficientBalance(Acc, new LackBalanceEventArgs(amount, Acc.Balance));
                }
            }
            else
            {
                AtmInsufficientBalance(this, new LackBalanceEventArgs(amount,Balance));
            }
        }

        public Account userByCard(string card)
        {
            foreach (Account acc in DB)
            {
                if (acc.CardNumber == card)
                {
                    return acc;
                }
            }
            return null;
        }

        public event EventHandler<TransactionEventArgs> Transfered;
        public event EventHandler<EventArgs> UserDoesntExist;
        public event EventHandler<EventArgs> TransferToSelf;
        public void transfer(int amount, string card)
        {
            if (card != Acc.CardNumber)
            {
                if (Acc.Balance >= amount)
                {
                    if (loggedIn() && isMoreThanZero(amount))
                    {
                        Account recp = userByCard(card);
                        if (recp != null)
                        {
                            Acc.balanceChange(-amount);
                            recp.balanceChange(amount);
                            storageChanges();
                            Transfered(this, new TransactionEventArgs(amount, recp, Acc));
                        }
                        else
                        {
                            UserDoesntExist(this, new EventArgs());
                        }
                    }
                }
                else
                {
                    AccountInsufficientBalance(Acc, new LackBalanceEventArgs(amount, Acc.Balance));
                }
            }
            else
            {
                TransferToSelf(Acc, new EventArgs());
            }
        }

        public void storageChanges()
        {
            using (Stream stream = File.Open(StoragePath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                binaryFormatter.Serialize(stream, DB);
            }
        }

        public void loadFile(string path)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                DB = (List<Account>)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
