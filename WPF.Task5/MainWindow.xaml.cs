using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF.Task5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
    int bc = 0;
        int bc1 = 0;
        int bc2 = 0;
        public MainWindow()
    {
        InitializeComponent();
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
        if (textBox != null)
        {
            textBox.FontFamily = new FontFamily(fontName);
        }
    }

    private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        int fontSize = Convert.ToInt32(((sender as ComboBox).SelectedItem as TextBlock).Text);
        if (textBox != null)
        {
            textBox.FontSize = fontSize;
        }
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        if (textBox != null)
        {
            textBox.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
    private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
    {
        if (textBox != null)
        {
            textBox.Foreground = new SolidColorBrush(Colors.Red);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

        if ((textBox != null) && (bc % 2 == 0))
        {
            textBox.FontWeight = FontWeights.Bold;
            ButtonBold.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        else
        {
            if ((textBox != null) && (bc % 2 != 0))
            {
                textBox.FontWeight = FontWeights.Normal;
                ButtonBold.Background = null;
            }
        }
        bc++;
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

        if ((textBox != null) && (bc1 % 2 == 0))
        {
            textBox.FontStyle = FontStyles.Italic;
            ButtonItalic.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        else
        {
            if ((textBox != null) && (bc1 % 2 != 0))
            {
                textBox.FontStyle = FontStyles.Normal;
                ButtonItalic.Background = null;
            }
        }
        bc1++;
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {

        if ((textBox != null) && (bc2 % 2 == 0))
        {
            textBox.TextDecorations = TextDecorations.Underline;
            ButtonUnderlined.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        else
        {
            if ((textBox != null) && (bc2 % 2 != 0))
            {
                textBox.TextDecorations = null;
                ButtonUnderlined.Background = null;
            }
        }
        bc2++;
    }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
