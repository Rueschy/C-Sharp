using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Bank_Rüscher
{
    public class BankAccount
    {
        //fields
        double balance;
        double interestRate;
        string name;
        
        //properties
        public double Balance
        {
            get
            {
                return balance;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        //methods
        public BankAccount(string name, double balance, double interest)
        {
            this.name = name;
            this.balance = balance;
            this.interestRate = interest;
        }

        public override string ToString()
        {
            return name + " ~ this account holds " + balance + "€";
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public bool WithDraw(double amount)
        {
            if(amount < 0)
            {
                return false;
            }
            else if(amount > balance)
            {
                return false;
            }
            else
            {
                balance -= amount;
                return true;
            }
        }
    }
}
