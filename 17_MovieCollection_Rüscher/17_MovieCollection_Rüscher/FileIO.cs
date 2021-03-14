using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _17_MovieCollection_Rüscher
{
    public class FileIO
    {
        string path;

        public FileIO(string path)
        {
            this.path = path;
        }

        public Dictionary<string, Movie> ReadFile()
        {
            Dictionary<string, Movie> Movies = new Dictionary<string, Movie>();

            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);

                string line;
                line = reader.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(';');
                    Movie m = new Movie(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
                    Movies.Add(m.Title, m);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            return Movies;
        }

        public void WriteFile(List<Movie> movies)
        {
            StreamWriter writer = new StreamWriter(path, false);
            foreach (Movie m in movies)
            {
                writer.WriteLine(m.ToStringForFile());
            }
            writer.Close();
        }

        public void AddMovieToFile(Movie m)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(m.ToStringForFile());
            writer.Close();
        }
    }
}
