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

        private void zaloguj_Click(object sender, RoutedEventArgs e)
        {
            string Login = this.txtLogowanie.Text;
            string Haslo = this.boxHaslo.Password;
            if (!File.Exists(Login + ".txt"))
            {
                MessageBox.Show("Nie ma takiego użytkownika");
            }
            if (File.Exists(Login + ".txt"))
            {
                StreamReader Odczyt = new StreamReader(Login + ".txt");
                string Linia = Odczyt.ReadLine();
                bool SprawdzamLogin = Linia.Contains(Login);
                bool SprawdzamHaslo = Linia.Contains(Haslo);
                if (uzytkownik.Sprawdzam(Login, Haslo, Odczyt, SprawdzamLogin, SprawdzamHaslo))
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
            Application.Current.Shutdown();
        }

        private void ZalozKonto_Click(object sender, RoutedEventArgs e)
        {
            string Login = this.txtLogowanie.Text;
            string Haslo = this.boxHaslo.Password;
            uzytkownik.TworzeKonto(Login, Haslo);
        }

      
    
        
    }
}
