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

namespace _12_TranslateWithDictionary_Rüscher
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
            if(textBoxLanguage1.Text =="" && textBoxLanguage2.Text == "")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                string word1 = textBoxLanguage1.Text;
                string word2 = textBoxLanguage2.Text;

                dic.MakeEntry(word1, word2);
            }
        }

        private void buttonTranslate_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxWord.Text == "")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                string word = textBoxWord.Text;
                
                listBoxTranslation.ItemsSource = dic.Translate(word);
            }
        }
    }
}
