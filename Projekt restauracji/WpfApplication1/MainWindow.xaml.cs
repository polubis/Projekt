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
        
            ApplicationCommands.Open.InputGestures.Add(new KeyGesture(Key.Enter));  // Uzbrojenie kontrolek w skrot
        
        }

        private void zaloguj_Click(object sender, RoutedEventArgs e)
        {
            
            string login = this.txtLogowanie.Text;
            string haslo = this.boxHaslo.Password;
            bool[] TablicaPrawdy = new bool[ListaUzytkownikow.Count];
            foreach (var element in ListaUzytkownikow)
            {
                   bool wynik = element.SprawdzamLogowanie(login, haslo);          //Sprawdza warunek prawdziwosci hasla i loginu
                   for (int i = 0; i <ListaUzytkownikow.Count; i++)
                   {
                       TablicaPrawdy[i] = wynik;
                   }

                /*
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
                 * */
            }
           for(int j=0;j<ListaUzytkownikow.Count;j++)
           {
               if (TablicaPrawdy[j] == true)
               {
                   this.Hide();
                   Window1 ob1 = new Window1();
                   ob1.Show();
                 
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
