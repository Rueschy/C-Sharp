using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Students_Rüscher
{
    public class SchoolClass
    {
        //fields
        List<Student> students = new List<Student>();
        //double averageGrade;

        //properties
        public List<Student> AllStudents
        {
            get
            {
                return students;
            }
        }

        public List<Student> BestStudents
        {
            get
            {
                return students;
            }
        }

        public double AverageGrade
        {
            get
            {
                double studentGrade = 0;
                double count = 0;
                double averageGrade = 0;
                foreach (Student student in students)
                {
                    studentGrade = student.Grade + studentGrade;
                    count++;
                }

                averageGrade = studentGrade / count;
                return averageGrade;
            }
        }

        public bool Add(Student s)
        {
            if (!students.Contains(s))
            {
                students.Add(s);
                return true;
            }

            return false;
        }

        public bool Delete(Student s)
        {
            return false;
        }
    }
}
