using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _16_MaturaCatalog_Rüscher
{
    public class FileIO
    {
        //--fields--//
        string path;

        //--methods--//
        public FileIO(string path)
        {
            this.path = path;
        }

        public List<Exam> ReadFile()
        {
            List<Exam> exams = new List<Exam>();
            StreamReader reader = new StreamReader(path);
            try
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    //read line and split it into parts
                    //string[] parts = line.Split(';');
                    //int id = int.Parse(parts[0]);
                    //string student = parts[1];
                    //string subject = parts[2];
                    //int mark = int.Parse(parts[3]);

                    //create object and add it to collection
                    //Exam e = new Exam(id, student, subject);
                    //exams.Add(e);
                    //line = reader.ReadLine();

                    Exam e = new Exam(line);
                    exams.Add(e);
                    line = reader.ReadLine();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new FormatException("Can not read file format!", ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return exams;
        }

        public void WriteFile(Dictionary<int, Exam> exams)
        {
            if (File.Exists(path))
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(path);

                    foreach(Exam e in exams.Values)
                    {
                        writer.WriteLine(e.ToStringForFile());
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }
    }
}

