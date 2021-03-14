using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _03_Students_Rüscher
{
    public class FileIO
    {
        //fields
        string filename;

        //methods
        public FileIO(string filename)
        {
            this.filename = filename;
        }

        public List<Student> ReadStudent()
        {
            List<Student> students = new List<Student>();
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            while(line != null)
            {
                //read line and split it into parts
                string[] parts = line.Split('\t');
                string name = parts[1];
                int participation = int.Parse(parts[5]);

                //creat object and add to collection
                Student s = new Student(name);
                s.Participation = participation;
                students.Add(s);
                line = reader.ReadLine();
            }
            reader.Close();
            return students;
        }

        public void WriteStudent(List<Student> students)
        {
            if(filename != "")
            {
                StreamWriter writer = new StreamWriter(filename);   //open wtrier

                foreach (Student s in students)
                {
                    writer.WriteLine(s.ToString());                 // write name to file
                }
                writer.Close();                                     // close writer
            }
        }
    }
}
