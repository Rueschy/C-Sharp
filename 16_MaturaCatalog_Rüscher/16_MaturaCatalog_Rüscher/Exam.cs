using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_MaturaCatalog_Rüscher
{
    public delegate void ChangeEventHandler();

    public class Exam
    {
        //--fields--//
        int id;
        int mark = 0;
        string student;
        string subject;

        public event ChangeEventHandler ExamChanged;

        //--properties--//
        public int Id
        {
            get
            {
                return id;
            }
        }
        public int Mark
        {
            get
            {
                return mark;
            }
        }
        public string Student
        {
            get
            {
                return student;
            }
        }
        public string Subject
        {
            get
            {
                return subject;
            }
        }

        //--methods--//
        public Exam(int id, string name, string subject)
        {
            try
            {
                if(id < 0)
                {
                    throw new ArgumentException("ID have to be positive!");
                }
                else if(name =="" || subject == "")
                {
                    throw new ArgumentException("Name or Subject is emty!");
                }
                else
                {
                    this.id = id;
                    this.student = name;
                    this.subject = subject;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Exam(string line)
        {
            if(line != "")
            {
                string[] parts = line.Split(';');
                id = int.Parse(parts[0]);
                student = parts[1];
                subject = parts[2];
                mark = int.Parse(parts[3]);
            }
        }

        public void Rate(int mark)
        {
            try
            {
                if(mark < 1 || mark > 5)
                {
                    throw new ArgumentException("Only the numbers 1-5 are allowed!");
                }
                else
                {
                    this.mark = mark;

                    if (ExamChanged != null)
                    {
                        ExamChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            //return id + " " + student + " " + ":" + " " + subject + " " + "-" + " " + mark;
            return id + " " + student + ": " + subject + " - " + mark;
        }

        public string ToStringForFile()
        {
            return id + ";" + student + ";" + subject + ";" + mark;
        }
    }
}
