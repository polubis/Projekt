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
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Kalkulator.xaml
    /// </summary>
    public partial class Kalkulator : Window
    {
        enum Operation{brakOperacji = 0, dodawanie, odejmowanie, mnozenie, dzielenie, wynik}
        private Operation ostatnioWybranaOperacja = Operation.brakOperacji;
        public Kalkulator()
        {
            InitializeComponent();
            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.wynik == ostatnioWybranaOperacja)
            {
                txtDisplay.Text = string.Empty;
                ostatnioWybranaOperacja = Operation.brakOperacji;
            }
            Button oButton = (Button)sender;
            txtDisplay.Text += oButton.Content;
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
            txtDisplayOperation.Text = string.Empty;
            ostatnioWybranaOperacja = Operation.brakOperacji;
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Operation.wynik == ostatnioWybranaOperacja) ||
        (Operation.brakOperacji == ostatnioWybranaOperacja))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = "0";
            }
            switch (ostatnioWybranaOperacja)
            {
                case Operation.dodawanie:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) +
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.odejmowanie:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) -
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.mnozenie:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) *
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.dzielenie:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) /
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
            }
            ostatnioWybranaOperacja = Operation.wynik;
            txtDisplayOperation.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.wynik == ostatnioWybranaOperacja)
            {
                txtDisplay.Text = string.Empty;
                ostatnioWybranaOperacja = Operation.brakOperacji;
            }
            if ((txtDisplay.Text.Contains(',')) ||
                (0 == txtDisplay.Text.Length))
            {
                return;
            }
            txtDisplay.Text += ",";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Operation.brakOperacji != ostatnioWybranaOperacja) || (Operation.wynik != ostatnioWybranaOperacja))
            {
                ResultButton_Click(this, e);
            }
            Button oButton = (Button)sender;
            switch (oButton.Content.ToString())
            {
                case "+":
                    ostatnioWybranaOperacja = Operation.dodawanie;
                    break;
                case "-":
                    ostatnioWybranaOperacja = Operation.odejmowanie;
                    break;
                case "*":
                    ostatnioWybranaOperacja = Operation.mnozenie;
                    break;
                case "/":
                    ostatnioWybranaOperacja = Operation.dzielenie;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            txtDisplayMemory.Text = txtDisplay.Text;
            txtDisplayOperation.Text = oButton.Content.ToString();
            txtDisplay.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


      

       
    }
}
