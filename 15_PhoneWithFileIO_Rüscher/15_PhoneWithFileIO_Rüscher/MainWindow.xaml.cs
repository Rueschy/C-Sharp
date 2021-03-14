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

namespace _15_PhoneWithFileIO_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Phonebook book;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                book = new Phonebook();
                listBoxContacts.ItemsSource = book.Names;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text =="" || textBoxNummer.Text == "")
            {
                MessageBox.Show("Name or Nr is empty!");
            }
            else
            {
                string name = "";
                string phoneNumber = "";

                try
                {
                    name = textBoxName.Text;
                    phoneNumber = textBoxNummer.Text;

                    if (book.AddContact(name, phoneNumber) == false)
                    {
                        MessageBox.Show("Entry already exists!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshGUI();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxContacts.SelectedItem == null)
            {
                MessageBox.Show("Select a Name!");
            }
            else
            {
                try
                {
                    string name = (string)listBoxContacts.SelectedItem;
                    book.DeleteContact(name);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            RefreshGUI();
        }

        private void Favorits_Click(object sender, RoutedEventArgs e)
        {
            listBoxContacts.ItemsSource = book.Favourites;
        }

        private void buttonShowAll_Click(object sender, RoutedEventArgs e)
        {
            listBoxContacts.ItemsSource = book.Names;
        }

        private void buttonCall_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text =="" || textBoxMinutes.Text == "")
            {
                MessageBox.Show("Name or Minutes is empty!");
            }
            else
            {
                string name;
                double minutes;

                try
                {
                    name = textBoxName.Text;
                    minutes = double.Parse(textBoxMinutes.Text);

                    if(book.Call(name, minutes) == false)
                    {
                        MessageBox.Show("Contact not exists!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            textBoxName.Clear();
            textBoxNummer.Clear();
            textBoxMinutes.Clear();
            listBoxContacts.Items.Refresh();
        }

        private void checkBoxFavourit_Checked(object sender, RoutedEventArgs e)
        {
            if(listBoxContacts.SelectedItem == null)
            {
                MessageBox.Show("Select a Name!");
            }
            else
            {
                bool check = false;
                string name;
                try
                {
                    name = (string)listBoxContacts.SelectedItem;
                
                    if(checkBoxFavourit.IsChecked == true)
                    {
                        check = true;
                        book.SetFavourit(name, check);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            RefreshGUI();
        }

        private void listBoxContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = (string)listBoxContacts.SelectedItem;
            if (name != null)
            {
                Contact c = book.GetContact(name);

                if (c.IsFavorit == true)
                {
                    checkBoxFavourit.IsChecked = true;
                }
                else
                {
                    checkBoxFavourit.IsChecked = false;
                }

                listBoxHistory.ItemsSource = c.CallHistory;
                textBoxSumMinuten.Text = c.SumMinutes.ToString();
            }
        }
    }
}
