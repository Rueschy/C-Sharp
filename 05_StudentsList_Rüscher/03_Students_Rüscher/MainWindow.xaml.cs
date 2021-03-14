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

namespace _03_Students_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student s;
        List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();

            listBoxStudents.ItemsSource = students;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text == "")
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                string name = textBoxName.Text;
                s = new Student(name);

                if (!students.Contains(s))
                {
                    students.Add(s);
                    listBoxStudents.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("The name already exists!");
                }

                double averageGrade = AverageGrade();
                textBoxAverageGrade.Text = averageGrade.ToString();

                textBoxName.Clear();
                textBoxName.Focus();
            }
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            if(s == null)
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                s.Appreciate();
            }

            double averageGrade = AverageGrade();
            textBoxAverageGrade.Text = averageGrade.ToString();

            listBoxStudents.Items.Refresh();
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            if(s == null)
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                s.Depreciate();
            }

            double averageGrade = AverageGrade();
            textBoxAverageGrade.Text = averageGrade.ToString();

            listBoxStudents.Items.Refresh();
        }
        private double AverageGrade()
        {
            double studentGrade = 0;
            double count = 0;
            double averageGrade = 0;
            foreach(Student student in students)
            {
                studentGrade = student.Grade + studentGrade;
                count++;
            }

            averageGrade = studentGrade / count;
            return averageGrade;
        }
    }
}
