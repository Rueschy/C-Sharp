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

namespace _09_Bank_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank bank = new Bank();
        public MainWindow()
        {
            InitializeComponent();

            listBoxBankAccounts.ItemsSource = bank.BankAccounts;
            bank.Add("Marcel", 100, 2);
            bank.Add("Mika", 400, 1);
            bank.Add("Rene", 300, 4);
            bank.Add("Marcel", 500, 3);

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "" || textBoxAmount.Text == "" || textBoxInterest.Text == "")
            {
                MessageBox.Show("Name, Amount or Interest is empty!");
            }
            else
            {
                string name = textBoxName.Text;
                double balance = 0;
                double interest = 0;
                try
                {
                    balance = double.Parse(textBoxAmount.Text);
                    interest = double.Parse(textBoxInterest.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input!");
                }

                if (!bank.Add(name, balance, interest))
                {
                    MessageBox.Show("Amount or Interest is negativ!");
                }
                listBoxBankAccounts.Items.Refresh();
            }
        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Name is empty!");
            }
            else
            {
                string name = textBoxName.Text;

                listBoxBankAccounts.ItemsSource = bank.Find(name);
                listBoxBankAccounts.Items.Refresh();
            }
        }

        private void buttonShowAll_Click(object sender, RoutedEventArgs e)
        {
            listBoxBankAccounts.ItemsSource = bank.BankAccounts;
        }

        private void buttonDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxAmount.Text == "")
            {
                MessageBox.Show("Amount is empty!");
            }
            else
            {
                double amount = 0;

                try
                {
                    amount = double.Parse(textBoxAmount.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input!");
                }
                if (listBoxBankAccounts.SelectedItem != null)
                {
                    bank.Deposit((BankAccount)listBoxBankAccounts.SelectedItem, amount);
                }
                else
                {
                    MessageBox.Show("Select an Account!");
                }
                listBoxBankAccounts.Items.Refresh();
            }
        }

        private void buttonWithDraw_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxAmount.Text == "")
            {
                MessageBox.Show("Amount is empty!");
            }
            else
            {
                double amount = 0;

                try
                {
                    amount = double.Parse(textBoxAmount.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid Input!");
                }

                if(listBoxBankAccounts.SelectedItem != null)
                {
                    if(!bank.WithDraw((BankAccount)listBoxBankAccounts.SelectedItem, amount))
                    {
                        MessageBox.Show("Amount is negativ or greater than balance!");
                    }
                }
                else
                {
                    MessageBox.Show("Select an Account!");
                }
                listBoxBankAccounts.Items.Refresh();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxBankAccounts.SelectedItem == null)
            {
                MessageBox.Show("Select an Account!");
            }
            else
            {
                bank.Remove((BankAccount)listBoxBankAccounts.SelectedItem);
                listBoxBankAccounts.Items.Refresh();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
