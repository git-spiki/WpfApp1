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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _currentval = 0;
        private double _storedval = 0;
        private string _operation = "+";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();
            if (txtDisplay.Text == "0" && number != ".")
            {
                txtDisplay.Text = number;
            }
            else
            {
                txtDisplay.Text += number;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Content.ToString();
            _storedval = double.Parse(txtDisplay.Text);
            txtDisplay.Text = "0";
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            _currentval = double.Parse(txtDisplay.Text);
            switch (_operation)
            {
                case "-":
                    _currentval = _storedval - _currentval;
                    break;
                case "*":
                    _currentval *= _storedval;
                    break;
                case "/":
                    if (_currentval == 0)
                    {
                        MessageBox.Show("хлоп");
                        break;
                    }
                    _currentval = _storedval / _currentval;
                    break;
                default:
                    _currentval += _storedval;
                    break;
            }
            txtDisplay.Text = _currentval.ToString();
            _operation = "+";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            _storedval = 0;
            _currentval = 0;
        }
    }
}
