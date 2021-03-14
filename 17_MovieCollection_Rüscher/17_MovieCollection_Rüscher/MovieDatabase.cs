using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_MovieCollection_Rüscher
{
    public class MovieDatabase
    {
        //--Fields--//
        FileIO file;
        Dictionary<string, Movie> movies;

        //--Properties--//
        public Dictionary<string, Movie>.ValueCollection Movies
        {
            get
            {
                return movies.Values;
            }
        }

        public string Path
        {
            set
            {
                file = new FileIO(value);
            }
        }

        //--Methods--//
        public MovieDatabase(string path)
        {
            file = new FileIO(path);

            movies = new Dictionary<string, Movie>();
            movies = file.ReadFile();
        }

        public void RemoveMovie(Movie m)
        {
            try
            {
                if (movies.ContainsKey(m.Title))
                {
                    movies.Remove(m.Title);
                    file.WriteFile(this.Movies.ToList());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData()
        {
            file.WriteFile(this.Movies.ToList());
        }

        public void SaveMovie(Movie m)
        {
            if (movies.ContainsKey(m.Title))
            {
                RemoveMovie(m);
            }
            movies.Add(m.Title, m);
            file.AddMovieToFile(m);
        }

        public List<Movie> FilterByYear(int year)
        {
            List<Movie> filtered = new List<Movie>();

            foreach(Movie m in movies.Values)
            {
                if(m.Year == year)
                {
                    filtered.Add(m);
                }
            }
            return filtered;
        }

        public Movie GetByTitle(string title)
        {
            if (movies.ContainsKey(title))
            {
                foreach(Movie m in movies.Values)
                {
                    if(m.Title == title)
                    {
                        return m;
                    }
                }
            }
            else
            {
                return null;
            }
            return null;
        }
    }
}
