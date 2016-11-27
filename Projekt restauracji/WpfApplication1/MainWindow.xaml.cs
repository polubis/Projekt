using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uzytkownik uzytkownik = new Uzytkownik();
       
        public MainWindow()
        {
            InitializeComponent();
        

        }

        private void zaloguj_Click(object sender, RoutedEventArgs e)  // Przycisk do zalogowania
        {
            string Login = this.txtLogowanie.Text; 
            string Haslo = this.boxHaslo.Password;        // Pobieram wartosc wpisywane przez uzytkownika do TextBoxa i Password Boxa
            if (!File.Exists(Login + ".txt"))                       
            {
                MessageBox.Show("Nie ma takiego użytkownika");
            } 
            if (File.Exists(Login + ".txt"))                // W przypadku utworzenia pliku tekstowego z nazwa uzytkownika wykonuje ciag polecen
            {
                StreamReader Odczyt = new StreamReader(Login + ".txt");
                string Linia = Odczyt.ReadLine();                                              // Odczyt pliku tekstowego
                bool SprawdzamLogin = Linia.Contains(Login);
                bool SprawdzamHaslo = Linia.Contains(Haslo);                                      
                if (uzytkownik.Sprawdzam(Login, Haslo, Odczyt, SprawdzamLogin, SprawdzamHaslo))      // Jezeli taki uzytkownik istnieje i login, haslo sa poprawne to otwieram nowego okno.
                {
                    this.Hide();
                    Window1 Okno = new Window1();
                    Okno.Show();
                }
                else
                {
                    MessageBox.Show("Nie poprawne dane logowania");
                }
            }

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();                              // Zamykam aplikacje, przycisk wyjscie
        }

        private void ZalozKonto_Click(object sender, RoutedEventArgs e)
        {
            string Login = this.txtLogowanie.Text;                                  
            string Haslo = this.boxHaslo.Password;
            uzytkownik.TworzeKonto(Login, Haslo);                             // Zakladam konto, tworze nowy plik tekstowy z loginem i haslem w srodku.
        }

      
    
        
    }
}
