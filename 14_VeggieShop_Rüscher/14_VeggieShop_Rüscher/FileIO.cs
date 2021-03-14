using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _14_VeggieShop_Rüscher
{
    public class FileIO
    {
        //fields
        string path = @"..\..\Basket.txt";

        //methods
        public List<Veggi> ReadFile()
        {
            List<Veggi> veggies = new List<Veggi>();
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            while (line != null)
            {
                //read line and split it into parts
                string[] parts = line.Split('\t');
                string name = parts[1];
                double unitPrice = double.Parse(parts[3]);
                double amount = double.Parse(parts[5]);
                string category = parts[7];

                //creat object and add to collection
                Veggi v = new Veggi(name, unitPrice, amount, category);
                veggies.Add(v);
                line = reader.ReadLine();
            }
            reader.Close();
            return veggies;
        }

        public void SaveVeggiToFile(Veggi v)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(v.ToString());
            writer.Close();
        }

        public void UpdatedVeggies(List<Veggi> veggies)
        {
            StreamWriter writer = new StreamWriter(path);   // open writer
            foreach (Veggi v in veggies)
            {
                writer.WriteLine(v.ToString());                         // write name to file
            }
            writer.Close();                                 // close writer
        }
    }
}
