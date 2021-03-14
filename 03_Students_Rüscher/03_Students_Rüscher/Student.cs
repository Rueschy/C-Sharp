using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Students_Rüscher
{
    public class Student
    {
        //fields
        string name;
        int participation;

        //properties
        public double Grade
        {
            get
            {
                if (participation > 10)
                {
                    return 1;
                }
                else if (participation > 5)
                {
                    return 2;
                }
                else if (participation < 5 && participation > -5)
                {
                    return 3;
                }
                else if (participation < -5 && participation > -10)
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Participation
        {
            get
            {
                return participation;
            }
        }

        //methods
        public Student(string name)
        {
            this.name = name;
        }

        public void Appreciate()
        {
            participation += 1;
        }

        public void Depreciate()
        {
            participation -= 1;
        }

        public override string ToString()
        {
            return "Name: " + name + "\t" + "Grade: " + Grade + " Part.: " + participation;
        }
    }
}
