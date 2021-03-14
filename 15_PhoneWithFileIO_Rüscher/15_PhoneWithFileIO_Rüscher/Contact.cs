using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_PhoneWithFileIO_Rüscher
{
    public class Contact
    {
        //--fields--//
        List<double> callHistory = new List<double>();
        bool isFavorit;
        string name;
        string phoneNumber;

        //--properties--//
        public List<double> CallHistory
        {
            get
            {
                return callHistory;
            }
        }

        public bool IsFavorit
        {
            set
            {
                isFavorit = value;
            }
            get
            {
                return isFavorit;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
        }

        public double SumMinutes
        {
            get
            {
                double sumMinutes = 0;
                foreach(double m in callHistory)
                {
                    sumMinutes = sumMinutes + m;
                }

                return sumMinutes;
            }
        }

        //--methods--//
        public void Call(double minutes)
        {
            callHistory.Add(minutes);
        }

        public Contact(string name, string phoneNumber)
        {
            if(name == "" || phoneNumber == "")
            {
                throw new ArgumentException("Name or Nr ist leer!");
            }
            else
            {
                this.name = name;
                this.phoneNumber = phoneNumber;
            }
        }

        public string ToStringForFile()
        {
            return name + ";" + phoneNumber;
        }
    }
}
