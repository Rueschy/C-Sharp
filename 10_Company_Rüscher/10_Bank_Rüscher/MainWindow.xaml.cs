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

namespace _10_Bank_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company company = new Company();
        public MainWindow()
        {
            InitializeComponent();

            listBoxIDs.ItemsSource = company.Employees;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxID.Text =="" || textBoxName.Text == "")
            {
                MessageBox.Show("ID or Name is empty!");
            }
            else
            {
                string name = textBoxName.Text;
                int id = 0;
                try
                {
                    id = int.Parse(textBoxID.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                if(company.AddEmployee(id, name) == true)
                {
                    MessageBox.Show("Employee already exists!");
                }
                else
                {
                    listBoxIDs.Items.Refresh();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxIDs.SelectedItem == null)
            {
                MessageBox.Show("Select an Employee!");
            }
            else
            {
                company.Delete((Employee)listBoxIDs.SelectedItem);
                listBoxIDs.Items.Refresh();
            }
        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text == "")
            {
                MessageBox.Show("Enter a Name!");
            }
            else
            {
                string name = textBoxName.Text;

                listBoxIDs.ItemsSource = company.Find(name);
                listBoxIDs.Items.Refresh();
            }
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            listBoxIDs.ItemsSource = company.Employees;
            listBoxIDs.Items.Refresh();
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxIDs.SelectedItem == null)
            {
                MessageBox.Show("Select an Employee!");
            }
            else
            {
                if(textBoxName.Text == "")
                {
                    MessageBox.Show("Name is empty!");
                }
                else
                {
                    string name = textBoxName.Text;
                    Employee emp = (Employee)listBoxIDs.SelectedItem;

                    emp.Name = name;
                    listBoxIDs.Items.Refresh();
                }
            }
        }
    }
}
