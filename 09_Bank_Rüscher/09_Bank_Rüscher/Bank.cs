using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Bank_Rüscher
{
    public class Bank
    {
        BankAccount account;
        //fields
        List<BankAccount> bankAccounts = new List<BankAccount>();

        //properties
        public List<BankAccount> BankAccounts
        {
            get
            {
                return bankAccounts;
            }
        }

        //methods
        public bool Add(string name, double balance, double interest)
        {
            account = new BankAccount(name, balance, interest);
            if(balance >= 0 && interest >= 0)
            {
                bankAccounts.Add(account);
                return true;
            }
            return false;
        }
        public List<BankAccount> Find(string name)
        {
            List<BankAccount> filtered = new List<BankAccount>();

            foreach(BankAccount f in bankAccounts)
            {
                if(f.Name == name)
                {
                    filtered.Add(f);
                }
            }
            return filtered;
        }
        public void Deposit(BankAccount account, double amount)
        {
            if(account != null)
            {
                if(amount > 0)
                {
                    account.Deposit(amount);
                }
            }
        }
        public bool WithDraw(BankAccount account, double amount)
        {
            if(account != null)
            {
                if (!account.WithDraw(amount))
                {
                    return false;
                }
            }
            return true;
        }
        public void Remove(BankAccount account)
        {
            bankAccounts.Remove(account);
        }
    }
}
