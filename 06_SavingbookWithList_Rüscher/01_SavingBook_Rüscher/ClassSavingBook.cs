using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SavingBook_Rüscher
{
    public class ClassSavingbook
    {
        //fields
        private double capital;
        private double interest;
        private string name;

        //properties
        public double Capital
        {
            get
            {
                return capital;
            }
        }
        public double Interest
        {
            set
            {
                if (value >= 0)
                {
                    this.interest = value;
                }
                else
                {
                    this.interest = 1;
                }
            }
            get
            {
                return interest;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        //methodes
        public void PayIn(double amount)
        {
            capital = capital + amount;
        }

        public bool WithDraw(double amount)
        {
            bool success = true;

            if(amount > capital)
            {
                success = false;
            }
            else
            {
                capital = capital - amount;
            }

            return success;
        }

        public double CalcInterest(double duration)
        {
            while(duration > 0)
            {
                capital = (capital / 100) * interest + capital;
                duration--;
            }
            return capital;
        }

        public override string ToString()
        {
            return name + "\t" + capital + "\t" + interest;
        }

        public ClassSavingbook(string name)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            if(obj is ClassSavingbook)
            {
                ClassSavingbook otherSavingsBook = (ClassSavingbook)obj;
                if(otherSavingsBook.Name == this.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
