using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _17_MovieCollection_Rüscher
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private Movie movie;
        private MovieDatabase movieDB;

        public DetailWindow(MovieDatabase movieDB, Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            this.movieDB = movieDB;

            if(movie != null)
            {
                textBoxTitle.Text = movie.Title;
                textBoxTitle.IsEnabled = false;

                textBoxDirector.Text = movie.Director;
                textBoxYear.Text = movie.Year.ToString();
                textBoxRunTime.Text = movie.RunTime.ToString();
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (movie == null)
                {
                    movie = new Movie();
                    movie.Title = textBoxTitle.Text;
                }
                movie.Director = textBoxDirector.Text;
                movie.Year = int.Parse(textBoxYear.Text);
                movie.RunTime = int.Parse(textBoxRunTime.Text);
                movieDB.SaveMovie(movie);

                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
