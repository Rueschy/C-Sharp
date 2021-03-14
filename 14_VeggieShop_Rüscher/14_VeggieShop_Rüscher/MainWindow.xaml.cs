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

namespace _14_VeggieShop_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Basket basket = new Basket();
        public MainWindow()
        {
            InitializeComponent();

            listBoxVeggis.ItemsSource = basket.Veggies;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxVeggi.Text == "" || textBoxUnitPrice.Text == "" || textBoxAmount.Text == "")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                string name = textBoxVeggi.Text;
                double unitPrice = double.Parse(textBoxUnitPrice.Text);
                double amount = double.Parse(textBoxAmount.Text);
                string category = textBoxCategory.Text;

                Veggi v = new Veggi(name, unitPrice, amount, category);
                basket.AddVeggiToBasket(v);
                RefreshGUI();
            }
        }

        private void buttonPutBack_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxVeggis.SelectedItem == null)
            {
                MessageBox.Show("Select an Item!");
            }
            else if (textBoxAmount.Text == "")
            {
                MessageBox.Show("Amount is empty!");
            }
            else
            {
                double amount = double.Parse(textBoxAmount.Text);
                Veggi veggi = (Veggi)listBoxVeggis.SelectedItem;
                basket.RemoveVeggi(veggi, amount);

                RefreshGUI();
            }   
        }

        private void RefreshGUI()
        {
            listBoxVeggis.Items.Refresh();
            textBoxVeggi.Clear();
            textBoxUnitPrice.Clear();
            textBoxAmount.Clear();
            textBoxCategory.Clear();
            textBoxTotalPrice.Text = basket.TotalPrice.ToString();
        }

        private void listBoxVeggis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            Veggi veggi = (Veggi)listBoxVeggis.SelectedItem;

            if(veggi == null)
            {
                textBoxPrice.Text = "0";
            }
            else
            {
                double price = veggi.Amount * veggi.Price;
                textBoxPrice.Text = price.ToString();
            }
        }
    }
}
