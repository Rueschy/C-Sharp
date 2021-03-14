using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Bank_Rüscher
{
    public class Employee
    {
        //fields
        int id;
        string name;

        //properties
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        //methods
        public Employee(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override bool Equals(object obj)
        {
            if(obj is Employee)
            {
                Employee otherEmployee = (Employee)obj;
                if(otherEmployee.Id == this.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return "ID: " + id + "\t" + "Name: " + name;
        }
    }
}
