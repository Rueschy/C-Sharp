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

namespace _01_SavingBook_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ClassSavingbook> savingsBooks = new List<ClassSavingbook>();
        ClassSavingbook book;
        public MainWindow()
        {
            InitializeComponent();

            listBoxBooks.ItemsSource = savingsBooks;
        }

        private void buttonPayIn_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxAmount.Text == "")
            {
                MessageBox.Show("Amount is empty!");
            }
            else
            {
                if ((ClassSavingbook)listBoxBooks.SelectedItem == null)
                {
                    MessageBox.Show("Select a Name!");
                }
                else
                {
                    double amount = double.Parse(textBoxAmount.Text);

                    book.PayIn(amount);
                    listBoxBooks.Items.Refresh();
                    CurrentCapital();
                }
            }
            textBoxAmount.Clear();
        }

        private void buttonWithDraw_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxAmount.Text == "")
            {
                MessageBox.Show("Amount is empty!");
            }
            else
            {
                if ((ClassSavingbook)listBoxBooks.SelectedItem == null)
                {
                    MessageBox.Show("Select a Name!");
                }
                else
                {
                    double amount = double.Parse(textBoxAmount.Text);

                    bool success = book.WithDraw(amount);
                    if (success == true)
                    {
                        CurrentCapital();
                    }
                    else
                    {
                        MessageBox.Show("You haven't enough money!");
                    }
                    listBoxBooks.Items.Refresh();
                }
            }
            textBoxAmount.Clear();
        }

        private void buttonChangeInterest_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxInterest.Text == "")
            {
                MessageBox.Show("Interest is empty!");
            }
            else
            {
                if ((ClassSavingbook)listBoxBooks.SelectedItem == null)
                {
                    MessageBox.Show("Select a Name!");
                }
                else
                {
                    double interest = double.Parse(textBoxInterest.Text);

                    book.Interest = interest;
                }
                listBoxBooks.Items.Refresh();
            }
        }

        private void buttonCalculateInterest_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxDuration.Text == "")
            {
                MessageBox.Show("Duration is empty!");
            }
            else
            {
                if ((ClassSavingbook)listBoxBooks.SelectedItem == null)
                {
                    MessageBox.Show("Select a Name!");
                }
                else
                {
                    double duration = int.Parse(textBoxDuration.Text);
                    book.CalcInterest(duration);
                    CurrentCapital();
                }
                listBoxBooks.Items.Refresh();
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text == "" || textBoxAmount.Text =="" || textBoxInterest.Text=="")
            {
                MessageBox.Show("Name, Amount or Interest is empty!");
            }
            else
            {
                string name = textBoxName.Text;
                double amount = double.Parse(textBoxAmount.Text);
                double interest = double.Parse(textBoxInterest.Text);
                book = new ClassSavingbook(name);

                book.PayIn(amount);
                book.Interest = interest;

                if (savingsBooks.Contains(book))
                {
                    MessageBox.Show("Name already exists!");
                }
                else
                {
                    savingsBooks.Add(book);
                    listBoxBooks.Items.Refresh();
                    CurrentCapital();
                }
            }
        }
        private void CurrentCapital()
        {
            textBoxCurrentCapital.Text = book.Capital.ToString();
        }
    }
}
