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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace _17_MovieCollection_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovieDatabase movieDB;
        string path = @"../../Movies.txt";

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                movieDB = new MovieDatabase(path);
                listBoxMovies.ItemsSource = movieDB.Movies;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //--Add--//
            DetailWindow dw;
            try
            {
                dw = new DetailWindow(movieDB, null);
                dw.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listBoxMovies.Items.Refresh();
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            //--Change--//
            DetailWindow dw;
            Movie m;

            if(listBoxMovies.SelectedItem == null)
            {
                MessageBox.Show("Please select a Movie!");
            }
            else
            {
                try
                {
                    m = (Movie)listBoxMovies.SelectedItem;
                    dw = new DetailWindow(movieDB, m);
                    dw.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxMovies.Items.Refresh();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            //--Delete--//
            if (listBoxMovies.SelectedItem == null)
            {
                MessageBox.Show("Please select a Movie!");
            }
            else
            {
                Movie m;
                try
                {
                    m = (Movie)listBoxMovies.SelectedItem;

                    MessageBoxResult result = MessageBox.Show("Do you really want to delete " + m.Title + " ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        movieDB.RemoveMovie(m); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxMovies.Items.Refresh();
        }

        private void buttonFilterByYear_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxFilterText.Text == "")
            {
                MessageBox.Show("Please enter a Year!");
            }
            else
            {
                int year;
                try
                {
                    year = int.Parse(textBoxFilterText.Text);
                    listBoxMovies.ItemsSource = movieDB.FilterByYear(year);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxMovies.Items.Refresh();
        }

        private void buttonGetByTitle_Click(object sender, RoutedEventArgs e)
        {
            //--GetByTitle--//
            if(textBoxFilterText.Text == "")
            {
                MessageBox.Show("Please enter A Title!");
            }
            else
            {
                string title;
                DetailWindow dw;

                try
                {
                    title = textBoxFilterText.Text;
                    Movie m = movieDB.GetByTitle(title);
                    dw = new DetailWindow(movieDB, m);
                    dw.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            listBoxMovies.Items.Refresh();
        }

        private void buttonShowAll_Click(object sender, RoutedEventArgs e)
        {
            //--ShowAll--//
            listBoxMovies.ItemsSource = movieDB.Movies;
            listBoxMovies.Items.Refresh();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            //--Load--//
            string filename = File(true);
            try
            {
                movieDB = new MovieDatabase(filename);
                listBoxMovies.ItemsSource = movieDB.Movies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            listBoxMovies.Items.Refresh();
        }

        private void buttonSaveAs_Click(object sender, RoutedEventArgs e)
        {
            //--Save--//
            string fileName = File(false);
            try
            {
                movieDB.Path = fileName;
                movieDB.SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string File(bool open)
        {
            FileDialog dialog;

            if (open == false)
            {
                dialog = new SaveFileDialog();
                dialog.FileName = "Document";
                dialog.DefaultExt = ".txt";
            }
            else
            {
                dialog = new OpenFileDialog();
                dialog.CheckFileExists = false; //kommt keine Fehlermeldung auch wenn es das File nicht gibt.
            }

            dialog.Filter = "Text documents (.txt) | *.txt|Comma Sep. Values (.csv)|*.csv";

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}
