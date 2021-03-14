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

        string filename = @"..\..\Students.txt";
        FileIO fileio;


        //properties
        public List<Student> AllStudents
        {
            get
            {
                fileio = new FileIO(filename);
                students = fileio.ReadStudent();
                return students;
            }
        }

        public List<Student> BestStudents
        {
            get
            {
                List<Student> bestStudents = new List<Student>();
                foreach(Student student in students)
                {
                    if(student.Grade < AverageGrade)
                    {
                        bestStudents.Add(student);
                    }
                }
                return bestStudents;
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
            if(s.Grade < 5)
            {
                students.Remove(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveStudents()
        {
            fileio = new FileIO(filename);
            fileio.WriteStudent(students);
        }
    }
}
