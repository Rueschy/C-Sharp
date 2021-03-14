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
        ClassSavingbook book = new ClassSavingbook();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonPayIn_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxAmount.Text == "")
            {
                MessageBox.Show("Amount is empty!");
            }
            else
            {
                double amount = double.Parse(textBoxAmount.Text);

                book.PayIn(amount);
                textBoxCurrentCapital.Text = book.Capital.ToString();
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
                double amount = double.Parse(textBoxAmount.Text);

                bool success = book.WithDraw(amount);
                if(success == true)
                {
                    textBoxCurrentCapital.Text = book.Capital.ToString();
                }
                else
                {
                    MessageBox.Show("You haven't enough money!");
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
                double interest = double.Parse(textBoxInterest.Text);

                book.Interest = interest;
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
                int duration = int.Parse(textBoxDuration.Text);

                book.CalcInterest(duration);
                textBoxCurrentCapital.Text = book.Capital.ToString();
            }
        }
    }
}
