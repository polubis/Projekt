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
        enum Operacja{brakOperacji = 0, dodawanie, odejmowanie, mnozenie, dzielenie, wynik} // Deklaracja operacji jakie beda wykonywane na kalkulatorze
        private Operacja ostatnioWybranaOperacja = Operacja.brakOperacji;        // Ustawienie operacji na brak operacji czyli 0, domyslnie zawsze zmienna ta bedzie miec wartosc 0 
        public Kalkulator()
        {
            InitializeComponent();
            
        }

        private void PrzyciskNumer_Click(object sender, RoutedEventArgs e) // Okreslenie dzialan dla przyciskow z numerami
        {
            if (Operacja.wynik == ostatnioWybranaOperacja) // Jezeli wynik jest rowny ostatnio wybranej operacji 0 lub innej 
            {
                txtWyswietlany.Text = string.Empty;              // To tekst wyswietlony bedzie pusty.
                ostatnioWybranaOperacja = Operacja.brakOperacji;
            }
            Button oButton = (Button)sender;                             
            txtWyswietlany.Text += oButton.Content;
        }

        private void PrzyciskCzyszczenia_Click(object sender, RoutedEventArgs e) // Czysci zawartosci, ktore sa wyswietlane i zeruje operacje
        {
            txtWyswietlany.Text = string.Empty;
            txtWyswietlany2.Text = string.Empty;
            txtOperacja.Text = string.Empty;
            ostatnioWybranaOperacja = Operacja.brakOperacji;
        }

        private void PrzyciskWyniku_Click(object sender, RoutedEventArgs e) // Przycisk wynikowy
        {
            if ((Operacja.wynik == ostatnioWybranaOperacja)||(Operacja.brakOperacji == ostatnioWybranaOperacja))  // Sprawdza czy wynik nie jest rowny ostatnio wybranej operacji badz nierowny 0
            {
                return;
            }
            if (string.IsNullOrEmpty(txtWyswietlany.Text)) // Jezeli wartosc jest pusta to poprostu przyporzadkowuje jej 0.
            {
                txtWyswietlany.Text = "0";
            }
            switch (ostatnioWybranaOperacja)  // Implementacja dzialan na kalkulatorze
            {
                case Operacja.dodawanie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) +
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
                case Operacja.odejmowanie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) -
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
                case Operacja.mnozenie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) *
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
                case Operacja.dzielenie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) /
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
            }
            ostatnioWybranaOperacja = Operacja.wynik;  // Zeruje wartosci 
            txtOperacja.Text = string.Empty;
            txtWyswietlany2.Text = string.Empty;
        }

        private void PrzyciskDodajacyZnak_Click(object sender, RoutedEventArgs e) // Dodaje znak przecinka do liczb zmienno przecinkowych
        {
            if (Operacja.wynik == ostatnioWybranaOperacja)
            {
                txtWyswietlany.Text = string.Empty;
                ostatnioWybranaOperacja = Operacja.brakOperacji;
            }
            if ((txtWyswietlany.Text.Contains(',')) ||  // jezeli wyswietlany tekst zawiera przecinek badz jeglo dlugosc jest rowna 0 to zwraca ten tekst
                (0 == txtWyswietlany.Text.Length))
            {
                return;
            }
            txtWyswietlany.Text += ",";  // Dodaje do tekstu znak przecinka
        }

        private void PrzyciskOperacji_Click(object sender, RoutedEventArgs e) // Zainicjalizowanie przyciskow operacji
        {
            if ((Operacja.brakOperacji != ostatnioWybranaOperacja) || (Operacja.wynik != ostatnioWybranaOperacja))
            {
                PrzyciskWyniku_Click(this, e);
            }
            Button oButton = (Button)sender;
            switch (oButton.Content.ToString())
            {
                case "+":
                    ostatnioWybranaOperacja = Operacja.dodawanie;
                    break;
                case "-":
                    ostatnioWybranaOperacja = Operacja.odejmowanie;
                    break;
                case "*":
                    ostatnioWybranaOperacja = Operacja.mnozenie;
                    break;
                case "/":
                    ostatnioWybranaOperacja = Operacja.dzielenie;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            txtWyswietlany2.Text = txtWyswietlany.Text;
            txtOperacja.Text = oButton.Content.ToString();
            txtWyswietlany.Text = string.Empty;
        }

        private void Zamykam_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


      

       
    }
}
