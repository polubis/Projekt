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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Uzytkownik> ListaUzytkownikow = new ObservableCollection<Uzytkownik>();
       
        public MainWindow()
        {
            InitializeComponent();
            ListaUzytkownikow.Add(new Uzytkownik("wlasciciel","przystan"));
            ListaUzytkownikow.Add(new Uzytkownik("pracownik", "przystan"));
            ListaUzytkownikow.Add(new Uzytkownik("pracownik", "przystan1"));
        
  
        
        }

        private void zaloguj_Click(object sender, RoutedEventArgs e)
        {
            
            string Login = this.txtLogowanie.Text;
            string Haslo = this.boxHaslo.Password;
            bool[] TablicaPrawdy = new bool[ListaUzytkownikow.Count];
            int i = 0;
            foreach (var element in ListaUzytkownikow)
            {
                   bool wynik = element.SprawdzamLogowanie(Login, Haslo);          //Sprawdza warunek prawdziwosci hasla i loginu
                   TablicaPrawdy[i] = wynik;
                   i++;
                   
            }
            // dobrze dotad 
           for(int j=0;j<ListaUzytkownikow.Count;j++)
           {
               if (TablicaPrawdy[j] == true)
               {
                   
                   this.Hide();
                   Window1 ob1 = new Window1();
                   ob1.Show();
                   break;
               }
                  
               else
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
    
        
    }
}
