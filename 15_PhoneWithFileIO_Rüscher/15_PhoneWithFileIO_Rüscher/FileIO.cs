using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _15_PhoneWithFileIO_Rüscher
{
    public class FileIO
    {
        //--fields--//
        string path = @"..\..\Phonebook.txt";

        //--methods--//
        public Dictionary<string, Contact> ReadFile()
        {
            Dictionary<string, Contact> phonebook = new Dictionary<string, Contact>();
            StreamReader reader = new StreamReader(path);
            try
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    //read line and split it into parts
                    string[] parts = line.Split(';');
                    string name = parts[0];
                    string number = parts[1];

                    //create object and add it to collection
                    Contact c = new Contact(name, number);
                    phonebook.Add(name, c);
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
            return phonebook;
        }

        public void SaveContactToFile(Contact c)
        {
            StreamWriter writer = new StreamWriter(path, true);
            try
            {
                writer.WriteLine(c.ToStringForFile());
            }
            catch(IOException ex)
            {
                throw new IOException("Contact could not be saved!", ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public void RewriteAllContactsToFile(List<Contact> contacts)
        {
            StreamWriter writer = new StreamWriter(path, false);
            try
            {
                foreach(Contact c in contacts)
                {
                    writer.WriteLine(c.ToStringForFile());
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
