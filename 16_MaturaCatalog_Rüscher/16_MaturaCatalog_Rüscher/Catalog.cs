using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_MaturaCatalog_Rüscher
{
    public class Catalog
    {
        //--fields--//
        Dictionary<int, Exam> exams;
        FileIO file;

        //--properties--//
        public Dictionary<int, Exam>.ValueCollection Exams
        {
            get
            {
                return exams.Values;
            }
        }

        //--methods--//
        public Catalog(string filePath)
        {
            file = new FileIO(filePath);
            exams = new Dictionary<int, Exam>();

            List<Exam> ex = file.ReadFile();
           
            foreach (Exam e in ex)
            {
                exams.Add(e.Id, e);
                e.ExamChanged += Save;
            }
        }

        public bool Add(Exam e)
        {
            foreach(Exam exam in exams.Values)
            {
                if(exam.Student == e.Student)
                {
                    if(exam.Subject == e.Subject)
                    {
                        return false;
                    }
                    else
                    {
                        exams.Add(e.Id, e);
                        file.WriteFile(exams);
                        e.ExamChanged += Save;
                        return true;
                    }
                }
                else
                {
                    exams.Add(e.Id, e);
                    return true;
                }
            }
            exams.Add(e.Id, e);
            Save();
            return true;
        }
        public double Average()
        {
            double average = 0;
            int mark = 0;
            int count = 0;
            foreach (Exam exam in exams.Values)
            {
                mark = mark + exam.Mark;
                count++;
            }
            if (count != 0)
            {
                average = mark / count;
            }
            return average;
        }

        public double Average(string student)
        {
            double average = 0;
            int mark = 0;
            int count = Count(student);
            foreach(Exam exam in exams.Values)
            {
                if(exam.Student == student)
                {
                    mark = mark + exam.Mark;
                }
            }
            average = mark / count;
            return average;
        }

        private int Count(string student)
        {
            int count = 0;
            foreach(Exam exam in exams.Values)
            {
                if(exam.Student == student)
                {
                    count++;
                }
            }
            return count;
        }

        public Exam Get(int id)
        {
            foreach(Exam e in exams.Values)
            {
                if(e.Id == id)
                {
                    return e;
                }
            }
            return null;
        }

        public List<Exam> Select(string student)
        {
            List<Exam> ex = new List<Exam>();

            foreach(Exam e in exams.Values)
            {
                if(e.Student == student)
                {
                    ex.Add(e);
                }
            }
            return ex;
        }

        public void Save()
        {
            file.WriteFile(exams);
        }
    }
}
