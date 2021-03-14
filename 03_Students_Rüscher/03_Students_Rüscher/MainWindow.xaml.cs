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
        public MainWindow()
        {
            InitializeComponent();
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
            }

            textBoxOutput.Text = s.ToString();
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

            textBoxOutput.Text = s.ToString();
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

            textBoxOutput.Text = s.ToString();
        }
    }
}
