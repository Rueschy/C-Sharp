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

        public double CalcInterest(int duration)
        {
            while(duration > 0)
            {
                capital = (capital / 100) * interest + capital;
                duration--;
            }
            return capital;
        }
    }
}
