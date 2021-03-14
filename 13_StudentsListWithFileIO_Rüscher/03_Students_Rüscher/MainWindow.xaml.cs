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

namespace _03_Students_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student s;
        SchoolClass school = new SchoolClass();
        public MainWindow()
        {
            InitializeComponent();

            listBoxStudents.ItemsSource = school.AllStudents;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                string name = textBoxName.Text;
                s = new Student(name);

                //if (s != null)
                //{
                //    bool check = school.Add(s);
                //    if(check == true)
                //    {
                //        listBoxStudents.ItemsSource = school.AllStudents;
                //        listBoxStudents.Items.Refresh();
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Name is empty!");
                //}
                if(s != null)
                {
                    if(school.Add(s) == false)
                    {
                        MessageBox.Show("Name already exists!");
                    }
                }
                else
                {
                    MessageBox.Show("Name is empty!");
                }

                textBoxAverageGrade.Text = school.AverageGrade.ToString();

                RefreshGUI();
            }
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            if (s == null)
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                s.Appreciate();
            }

            textBoxAverageGrade.Text = school.AverageGrade.ToString();

            RefreshGUI();
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (s == null)
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                s.Depreciate();
            }

            textBoxAverageGrade.Text = school.AverageGrade.ToString();

            RefreshGUI();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if((Student)listBoxStudents.SelectedItem == null)
            {
                MessageBox.Show("Select a Student!");
            }
            else
            {
                s = (Student)listBoxStudents.SelectedItem;

                bool check = school.Delete(s);
                if(check == true)
                {
                    textBoxAverageGrade.Text = school.AverageGrade.ToString();

                    listBoxStudents.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Student isn't positiv!");
                }
            }

            RefreshGUI();
        }

        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            if(school.AllStudents == null)
            {
                MessageBox.Show("No students are in the list!");
            }
            else
            {
                listBoxStudents.ItemsSource = school.BestStudents;
                listBoxStudents.Items.Refresh();
            }

            textBoxAverageGrade.Text = school.AverageGrade.ToString();
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            listBoxStudents.ItemsSource = school.AllStudents;
            listBoxStudents.Items.Refresh();
        }

        private void RefreshGUI()
        {
            textBoxName.Clear();
            textBoxName.Focus();
            listBoxStudents.Items.Refresh();

            school.SaveStudents();
        }
    }
}
