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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
          
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void zaloguj_Click(object sender, RoutedEventArgs e)
        {
             List<Uzytkownicy> listaUzytkownikow = new List<Uzytkownicy>();
             listaUzytkownikow.Add(new Uzytkownicy() { Login = "szefo1", Haslo = "niemawyplaty" });
             listaUzytkownikow.Add(new Uzytkownicy() {Login="kelner", Haslo="pracapraca"});
             listaUzytkownikow.Add(new Uzytkownicy() { Login = "kelner1", Haslo = "kelner1" });
            string login = this.txtLogowanie.Text;
            string haslo = this.boxHaslo.Password;
            foreach (var element in listaUzytkownikow)
            {
                    bool wynik = checkPass(login, haslo, element.Login, element.Haslo);  // sprawdza warunek prawdziwosci hasla i loginu
                    if (wynik == true)
                    {
                        this.Hide();
                        Window1 ob1 = new Window1();
                        ob1.Show();
                        break;
                    }
                    else if (wynik == false)
                    {
                        MessageBox.Show("Wpisales nie poprawne dane !");
                        break;
                    }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public bool checkPass(string login,string pass,string ElemLog,string ElemPass)
        {
            if (login == ElemLog && pass==ElemPass)
                return true;
            else 
                return false;
        }
        
    }
}
