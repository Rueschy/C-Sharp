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

namespace _16_MaturaCatalog_Rüscher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Catalog catalog;
        string filePath = @"..\..\exams.txt";

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                catalog = new Catalog(filePath);

                listBoxExams.ItemsSource = catalog.Exams;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RefreshGUI();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxID.Text == "" || textBoxStudent.Text == "" || textBoxSubject.Text == "")
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                int id = 0;
                string student = "";
                string subject = "";
                Exam exam;

                try
                {
                    id = int.Parse(textBoxID.Text);
                    student = textBoxStudent.Text;
                    subject = textBoxSubject.Text;

                    exam = new Exam(id, student, subject);

                    if (catalog.Add(exam) == false)
                    {
                        MessageBox.Show("Entry already exsists!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            RefreshGUI();
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxStudent.Text == "")
            {
                MessageBox.Show("Student is empty!");
            }
            else
            {
                string student = textBoxStudent.Text;
                listBoxExams.ItemsSource = catalog.Select(student);
            }
            RefreshGUI();
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            listBoxExams.ItemsSource = catalog.Exams;
            RefreshGUI();
        }

        private void buttonRate_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxMark.Text == "")
            {
                MessageBox.Show("Mark is empty!");
            }
            else
            {
                if (listBoxExams.SelectedItem == null)
                {
                    MessageBox.Show("Select an Exam!");
                }
                else
                {
                    Exam exam;
                    int mark = 0;

                    try
                    {
                        exam = (Exam)listBoxExams.SelectedItem;
                        mark = int.Parse(textBoxMark.Text);

                        exam.Rate(mark);
                        //catalog.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            RefreshGUI();
        }

        private void listBoxExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Exam exam;
            double result = 0;
            try
            {
                exam = (Exam)listBoxExams.SelectedItem;
                result = catalog.Average(exam.Student);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Select an Exam!");
            }

            textBoxResult.Text = result.ToString();
        }

        private void RefreshGUI()
        {
            textBoxID.Clear();
            textBoxStudent.Clear();
            textBoxSubject.Clear();
            textBoxMark.Clear();

            textBoxID.Focus();

            textBoxResult.Text = catalog.Average().ToString();
            listBoxExams.Items.Refresh();
        }
    }
}
