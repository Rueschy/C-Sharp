using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _14_VeggieShop_Rüscher
{
    public class Veggi
    {
        //fields
        double amount;
        string category;
        string name;
        double unitPrice;

        //properties
        public double Amount
        {
            get
            {
                return amount;
            }
        }
        public double Price
        {
            set
            {
                if (category == "B")
                {
                    unitPrice = unitPrice - ((unitPrice / 100) * 5);
                }
                else if (category == "C")
                {
                    unitPrice = unitPrice - ((unitPrice / 100) * 10);
                }
            }

            get
            {
                return unitPrice;
            }
        }

        //methods
        public Veggi(string name, double unitPrice, double amount, string category)
        {
            if (name == "")
            {
                this.name = "No Name!";
            }
            else
            {
                this.name = name;
            }

            if (unitPrice < 0)
            {
                this.unitPrice = 0;
            }
            else
            {
                this.unitPrice = unitPrice;
            }

            if (amount < 0)
            {
                this.amount = 0;
            }
            else
            {
                this.amount = amount;
            }

            if (category == "")
            {
                this.category = "A";
            }
            else
            {
                this.category = category;
            }
        }
        public override string ToString()
        {
            return "Product:" + "\t" + name + "\t" + "Unitprice:" + "\t" + unitPrice.ToString() + "\t" + "Amount:" + "\t" + amount.ToString() + "\t" + "Category:" + "\t" + category;
        }

        public override bool Equals(object obj)
        {
            if (obj is Veggi)
            {
                Veggi otherVeggi = (Veggi)obj;
                if (otherVeggi.name == this.name && otherVeggi.category == this.category && otherVeggi.unitPrice == this.unitPrice)
                {
                    return true;
                }
            }
            return false;
        }

        public void BuyMore(double amount)
        {
            //if (amount < 0)
            //{
            //    throw new ArgumentException("Amount must be positive!");
            //}
            //else
            //{
            //    this.amount = this.amount + amount;
            //}

            this.amount = this.amount + amount;
        }

        public void PutBack(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive!");
            }
            else
            {
                this.amount = this.amount - amount;
            }
        }
    }
}
