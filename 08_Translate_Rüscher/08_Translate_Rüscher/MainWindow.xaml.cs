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

namespace _08_Translate_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary dic = new Dictionary();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxLanguage1.Text =="" || textBoxLanguage2.Text =="")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                string word1 = textBoxLanguage1.Text;
                string word2 = textBoxLanguage2.Text;

                if(dic.MakeEntry(word1, word2) == true)
                {
                    MessageBox.Show("Wordpair already exist!");
                }
                else
                {
                    MessageBox.Show("Success!");
                }
                listBoxTranslation.Items.Refresh();
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxSearch.Text == "")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                string searchWord = textBoxSearch.Text;

                listBoxTranslation.ItemsSource = dic.Search(searchWord);
                listBoxTranslation.Items.Refresh();
            }
        }

        private void buttonTranslate_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxSearch.Text == "")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                string searchWord = textBoxSearch.Text;

                listBoxTranslation.ItemsSource = dic.Translate(searchWord);
            }
        }
    }
}
