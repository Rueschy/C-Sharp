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

namespace _02_Points_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point p1;
        Point p2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 0;

            if (textBoxX.Text != "" && textBoxY.Text != "")
            {
                x = int.Parse(textBoxX.Text);
                y = int.Parse(textBoxY.Text);
            }
 
            if(p1 == null)
            {
                p1 = new Point(x, y);
                textBoxPoint1.Text = p1.ToString();
            }
            else if(p2 == null)
            {
                p2 = new Point(x, y);
                textBoxPoint2.Text = p2.ToString();
            }
            else
            {
                MessageBox.Show("You have already added 2 points!");
            }

            textBoxX.Clear();
            textBoxY.Clear();

            textBoxX.Focus();
        }

        private void buttonDistance_Click(object sender, RoutedEventArgs e)
        {
            double distance = p1.DistanceToPoint(p2);
            textBoxDistance.Text = distance.ToString();
        }
    }
}
